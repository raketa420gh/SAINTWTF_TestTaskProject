using System.Collections.Generic;
using UnityEngine;

public class ResourceContainerView : MonoBehaviour, IResourceContainerView
{
    [SerializeField] private Transform _containerPoint;
    [SerializeField] private Vector3 _stackDirection = Vector3.up;
    [SerializeField] private float _spacing = 0.1f;
    private IResourceContainer _resourceContainer;
    private Vector3 _nextFreeSlotPosition;
    
    public Transform Point => _containerPoint;

    private void OnDisable()
    {
        if (_resourceContainer == null)
            return;
        
        _resourceContainer.OnUpdated -= HandleContainerUpdateEvent;
    }

    public void Initialize(IResourceContainer container)
    {
        _resourceContainer = container;
        _resourceContainer.OnUpdated += HandleContainerUpdateEvent;
        _nextFreeSlotPosition = _containerPoint.position + _stackDirection.normalized * _spacing;
        
        UpdateView(container.Resources);
    }

    public Vector3 GetNextFreeSlotPosition()
    {
        return _nextFreeSlotPosition;
    }

    private void UpdateView(List<IResource> resources)
    {
        Vector3 resourcePosition = _containerPoint.position;

        for (var i = 0; i < resources.Count; i++)
        {
            var resource = resources[i];
            resourcePosition += _stackDirection.normalized * _spacing;
            resource.Transform.parent = _containerPoint;
            resource.Transform.position = resourcePosition;
            resource.Transform.forward = _containerPoint.forward;
            
            if (i == resources.Count - 1)
                _nextFreeSlotPosition = resourcePosition += _stackDirection.normalized * _spacing;
        }
    }

    private void HandleContainerUpdateEvent(IResourceContainer container)
    {
        UpdateView(container.Resources);
    }
}