using UnityEngine;

[RequireComponent(typeof(ResourceCollector))]
[RequireComponent(typeof(ResourceContainer))]
[RequireComponent(typeof(ResourceDispenser))]

public class PlayerUnit : MovableUnit
{
    [SerializeField] private int _backPackCapacity = 10;
    private IResourceContainer _container;
    private IResourceCollector _resourceCollector;
    private IResourceDispenser _resourceDispenser;

    protected override void Awake()
    {
        _container = GetComponent<IResourceContainer>();
        _container.Initialize(_backPackCapacity);
        _resourceCollector = GetComponent<IResourceCollector>();
        _resourceCollector.Initialize(_container);
        _resourceDispenser = GetComponent<IResourceDispenser>();
        _resourceDispenser.Initialize(_container);
        
        base.Awake();
    }
}