using UnityEngine;

public class ResourceProducer : MonoBehaviour, IResourceProducer
{
    [SerializeField] private ResourceProducerData _data;
    [SerializeField] private ResourceContainer _productContainer;
    [SerializeField] ResourceContainer _factoryContainer;
    private IResourceProducerBehaviour _behaviour;
    private IResourceFactory _resourceFactory;
    private IProductionBuilding _productionBuilding;

    public ResourceProducerData Data => _data;
    public IResourceContainer Container => _productContainer;
    
    public void Initialize(IProductionBuilding productionBuilding, IResourceFactory resourceFactory, IResourceProducerBehaviour behaviour, IResourceConsumer resourceConsumer)
    {
        _productionBuilding = productionBuilding;
        _resourceFactory = resourceFactory;
        _productContainer.Initialize(_data.ProductionContainerCapacity);
        _factoryContainer.Initialize(_data.ProductionContainerCapacity);
        _behaviour = behaviour;
        _behaviour.InitializeStateMachine(_productionBuilding, this, _resourceFactory, resourceConsumer, _factoryContainer);
    }

    public void StartProduce()
    {
        _behaviour.SetCheckingState();
    }

    public void StopProduce()
    {
        _behaviour.SetIdleState();
    }

    private void Update()
    {
        _behaviour?.UpdateCurrentState();
    }
}