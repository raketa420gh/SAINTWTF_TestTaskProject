using System.Collections.Generic;
using UnityEngine;

public class ResourceProducerProduceWithConsumptionState : ResourceProducerState
{
    private readonly IResourceProducerBehaviour _behaviour;
    private readonly IResourceConsumer _resourceConsumer;
    private readonly IResourceContainer _producerContainer;
    private readonly IResourceContainer _consumerContainer;
    private readonly IResourceContainer _factoryContainer;
    private readonly IResourceFactory _factory;
    private List<IResource> _consumptionResources;
    private int _toFactoryIterations;

    private Transform _factoryPoint;
    private float _timer;

    public ResourceProducerProduceWithConsumptionState(IResourceProducerBehaviour behaviour, IResourceProducer resourceProducer, 
        IResourceConsumer resourceConsumer, IResourceContainer factoryContainer, IResourceFactory factory) : base(resourceProducer)
    {
        _behaviour = behaviour;
        _resourceConsumer = resourceConsumer;
        _factoryContainer = factoryContainer;
        _factory = factory;
        _consumerContainer = _resourceConsumer.Container;
        _producerContainer = _resourceProducer.Container;
    }
    public override void Enter()
    {
        _timer = 0f;
        _toFactoryIterations = 0;
    }

    public override void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _resourceProducer.Data.ProduceTime)
        {
            TranslateToFactory();
            _behaviour.SetCheckingState();
        }
    }
    
    private void TranslateToFactory()
    {
        foreach (var consumptionResource in _consumptionResources)
        {
            _consumerContainer.TranslateToContainer(consumptionResource, _factoryContainer, _resourceProducer.Data.TranslateAnimationTime);
        }
        
        _consumerContainer.OnTranslated += OnTranslated;
    }

    private void OnTranslated(IResource resource, IResourceContainer toContainer)
    {
        _toFactoryIterations++;
        
        if (_toFactoryIterations != 1) 
            return;
        
        var createdResource = _factory.CreateResource(_resourceProducer.Data.ProductionResourceType, _factoryContainer);
        _factoryContainer.TranslateToContainer(createdResource, _producerContainer, _resourceProducer.Data.TranslateAnimationTime);
        _factoryContainer.Clear();
        _consumerContainer.OnTranslated -= OnTranslated;
    }

    public void SetProduceResources(List<IResource> consumptionResources)
    {
        _consumptionResources = consumptionResources;
    }
}