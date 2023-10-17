public interface IResourceConsumer
{
    ResourceConsumerData Data { get; }
    IResourceContainer Container { get; }

    void Initialize();
}