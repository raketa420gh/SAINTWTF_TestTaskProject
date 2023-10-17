using UnityEngine;

public class ResourceProducerProduceNoConsumptionState : ResourceProducerState
{
    private readonly IResourceProducerBehaviour _behaviour;
    private readonly IResourceFactory _resourceFactory;
    private readonly IResourceContainer _factoryContainer;
    private readonly IResourceContainer _producerContainer;
    private float _timer;

    public ResourceProducerProduceNoConsumptionState(IResourceProducerBehaviour behaviour, IResourceProducer resourceProducer, 
        IResourceFactory resourceFactory, IResourceContainer factoryContainer, IResourceContainer producerContainer) : base(resourceProducer)
    {
        _behaviour = behaviour;
        _resourceFactory = resourceFactory;
        _factoryContainer = factoryContainer;
        _producerContainer = producerContainer;
    }

    public override void Enter()
    {
        _timer = 0f;
    }

    public override void Update()
    {
        _timer += Time.deltaTime;

        if (!(_timer >= _resourceProducer.Data.ProduceTime)) 
            return;
        
        ProduceResource();
        _behaviour.SetCheckingState();
    }

    private void ProduceResource()
    {
        var createdResource =
            _resourceFactory.CreateResource(_resourceProducer.Data.ProductionResourceType, _factoryContainer);
        
        _factoryContainer.TranslateToContainer(createdResource, _producerContainer, _resourceProducer.Data.TranslateAnimationTime);
        _factoryContainer.Clear();
    }
}