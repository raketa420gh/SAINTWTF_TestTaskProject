using System;
using UnityEngine;

public class Resource : MonoBehaviour, IResource
{
    [SerializeField] private MeshRenderer _meshRenderer;
    public Transform _moveToTransform;
    float _moveDuration = 1f;
    private bool _isTranslated;
    private ResourceType _type;

    public event Action OnTranslated;
    public ResourceType Type => _type;
    public Transform Transform => transform;
    
    private void Update()
    {
        if (!_isTranslated)
            return;
        
        float t = Mathf.PingPong(Time.time, _moveDuration) / _moveDuration;
        transform.position = Vector3.Lerp(transform.position, _moveToTransform.position, t);

        if (Vector3.Distance(transform.position, _moveToTransform.position) <= Single.Epsilon)
        {
            _isTranslated = false;
            OnTranslated?.Invoke();
        }
    }

    public void Initialize(ResourceData data)
    {
        _type = data.Type;
        _meshRenderer.material.color = data.Color;
        _isTranslated = false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void TranslateTo(Transform target)
    {
        _moveToTransform = target;
        _isTranslated = true;
    }

    public void Pickup(IResourceContainer container)
    {
        container.Add(this);
    }
}