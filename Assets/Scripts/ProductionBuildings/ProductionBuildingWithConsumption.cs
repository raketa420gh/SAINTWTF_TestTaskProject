using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(ResourceProducer))]
[RequireComponent(typeof(ResourceConsumer))]

public class ProductionBuildingWithConsumption : ProductionBuilding
{
    [SerializeField] private bool _produceAtStart;
    [SerializeField] private List<ResourceType> _startConsumptionResources;
    [SerializeField] private ResourceFactory _resourceFactory;
    private IResourceProducer _resourceProducer;
    private IResourceConsumer _resourceConsumer;

    protected override void Awake()
    {
        _resourceProducer = GetComponent<IResourceProducer>();
        _resourceConsumer = GetComponent<IResourceConsumer>();
        _resourceConsumer.Initialize();
        _resourceProducer.Initialize(this, _resourceFactory, new ResourceProducerWithConsumptionBehaviour(), _resourceConsumer);
        
        base.Awake();
    }

    private void Start()
    {
        if (_startConsumptionResources is { Count: > 0 })
        {
            foreach (var consumptionResource in _startConsumptionResources)
            {
                _resourceFactory.CreateResource(consumptionResource, _resourceConsumer.Container);
            }
        }
        
        if (_produceAtStart)
            _resourceProducer.StartProduce();
    }

    [Button]
    private void AddConsumptionResource(ResourceType type)
    {
        _resourceFactory.CreateResource(type, _resourceConsumer.Container);
    }
}