using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(ResourceContainerView))]

public class ResourceContainer : MonoBehaviour, IResourceContainer
{
    private IResourceContainerView _containerView;
    private List<IResource> _currentResources;
    private int _capacity;
    private bool _isFull;
    private bool _isEmpty;
    private bool _isAvailable;

    public event Action<IResourceContainer> OnUpdated;
    public event Action<IResource, IResourceContainer> OnTranslated;

    public IResourceContainerView View => _containerView;
    public List<IResource> Resources => _currentResources;
    public bool IsFull => _isFull;
    public bool IsEmpty => _isEmpty;
    public bool IsAvailable => _isAvailable;
    public Transform Point => View.Point;

    public void Initialize(int capacity)
    {
        _isAvailable = true;
        _currentResources = new List<IResource>();
        _capacity = capacity;
        _containerView = GetComponent<IResourceContainerView>();
        _containerView.Initialize(this);

        UpdateState();
    }

    public bool Add(IResource resource)
    {
        if (!_isAvailable)
            return false;
        
        if (resource == null)
            return false;

        if (_currentResources.Count >= _capacity)
            return false;

        _currentResources.Add(resource);

        UpdateState();

        return true;
    }
    
    public void Remove(IResource resource)
    {
        if (!_isAvailable)
            return;
        
        if (resource == null)
            return;
        
        if (!_currentResources.Contains(resource))
            return;

        _currentResources.Remove(resource);
            
        UpdateState();
    }

    public void Clear()
    {
        _currentResources.Clear();
        
        UpdateState();
    }

    public bool GetResourceByType(ResourceType type, out IResource resource)
    {
        List<IResource> allResourcesByType = _currentResources.Where(resource => resource.Type == type).ToList();

        if (allResourcesByType.Count > 0)
        {
            resource = allResourcesByType[0];
            return true;
        }

        resource = null;
        return false;
    }

    public bool GetLastResource(out IResource resource)
    {
        if (_currentResources.Count == 0)
        {
            resource = null;
            return false;
        }

        resource = _currentResources.Last();
        return true;
    }

    public void TranslateToContainer(IResource resource, IResourceContainer container, float time)
    {
        if (resource == null)
            return;
        
        if (!_currentResources.Contains(resource))
            return;
        
        if (container.IsFull)
            return;

        _currentResources.Remove(resource);
        
        _isAvailable = false;

        resource.Transform.parent = container.Point;

        var translateTween = resource.Transform.DOLocalMove(Vector3.zero, time);
        translateTween.onComplete += () =>
        {
            _isAvailable = true;
            container.Add(resource);

            OnTranslated?.Invoke(resource, container);
            
            UpdateState();
        };
    }

    private void UpdateState()
    {
        int resourcesCount = _currentResources.Count;

        if (resourcesCount == _capacity)
        {
            _isFull = true;
            _isEmpty = false;
        }

        if (resourcesCount == 0)
        {
            _isFull = false;
            _isEmpty = true;
        }

        if (resourcesCount > 0 && resourcesCount < _capacity)
        {
            _isFull = false;
            _isEmpty = false;
        }
        
        if (resourcesCount < 0 || resourcesCount > _capacity)
            Debug.LogError($"{this} container capacity error");
        
        OnUpdated?.Invoke(this);
    }
}