public interface IResourceProducer
{
    ResourceProducerData Data { get; }
    IResourceContainer Container { get; }
    
    void Initialize(IProductionBuilding productionBuilding, IResourceFactory resourceFactory, IResourceProducerBehaviour behaviour, 
        IResourceConsumer resourceConsumer);
    void StartProduce();
    void StopProduce();
}