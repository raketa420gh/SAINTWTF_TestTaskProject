public class ResourceProducerIdleState : ResourceProducerState
{
    private readonly IResourceProducer _resourceProducer;

    public ResourceProducerIdleState(IResourceProducer resourceProducer) : base(resourceProducer)
    {
        _resourceProducer = resourceProducer;
    }
}