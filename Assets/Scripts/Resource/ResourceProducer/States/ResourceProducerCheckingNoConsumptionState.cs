using UnityEngine;

public class ResourceProducerCheckingNoConsumptionState : ResourceProducerState
{
    private new readonly IResourceProducer _resourceProducer;
    private readonly IResourceProducerBehaviour _behaviour;
    private readonly IProductionBuilding _productionBuilding;
    private float _timer;

    public ResourceProducerCheckingNoConsumptionState(IResourceProducer resourceProducer,
        IResourceProducerBehaviour behaviour, IProductionBuilding productionBuilding) : base(resourceProducer)
    {
        _resourceProducer = resourceProducer;
        _behaviour = behaviour;
        _productionBuilding = productionBuilding;
    }

    public override void Enter()
    {
        _timer = 0f;

        if (CanProduce())
        {
            _behaviour.SetProductionState(null);
            _productionBuilding.UpdateStatus(ProductionBuildingStatusType.Work);
        }
        else
        {
            _productionBuilding.UpdateStatus(ProductionBuildingStatusType.StopIsFull);
        }
    }

    public override void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _resourceProducer.Data.CheckingInterval)
            _behaviour.SetCheckingState();
    }

    private bool CanProduce()
    {
        return !_resourceProducer.Container.IsFull;
    }
}