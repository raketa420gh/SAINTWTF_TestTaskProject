public class ResourceProducerState : BaseState
{
    protected readonly IResourceProducer _resourceProducer;

    protected ResourceProducerState(IResourceProducer resourceProducer)
    {
        _resourceProducer = resourceProducer;
    }
}