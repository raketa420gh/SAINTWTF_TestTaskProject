using System.Collections.Generic;
using UnityEngine;

public class ResourceProducerCheckingWithConsumptionState : ResourceProducerState
{
    private readonly IResourceProducerBehaviour _behaviour;
    private new readonly IResourceProducer _resourceProducer;
    private readonly IResourceConsumer _resourceConsumer;
    private readonly IProductionBuilding _productionBuilding;
    private float _timer;

    public ResourceProducerCheckingWithConsumptionState(ResourceProducerWithConsumptionBehaviour behaviour, IResourceProducer resourceProducer,
        IResourceConsumer resourceConsumer, IProductionBuilding productionBuilding) : base(resourceProducer)
    {
        _behaviour = behaviour;
        _resourceProducer = resourceProducer;
        _resourceConsumer = resourceConsumer;
        _productionBuilding = productionBuilding;
    }

    public override void Enter()
    {
        _timer = 0f;

        if (!CanProduce(out List<IResource> consumptionResources)) 
            return;
            
        _productionBuilding.UpdateStatus(ProductionBuildingStatusType.Work);
        _behaviour.SetProductionState(consumptionResources);
    }

    public override void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _resourceProducer.Data.CheckingInterval)
            _behaviour.SetCheckingState();
    }

    private bool CanProduce(out List<IResource> consumptionResources)
    {
        if (_resourceProducer.Container.IsFull) 
        {
            _productionBuilding.UpdateStatus(ProductionBuildingStatusType.StopIsFull);
            consumptionResources = null;
            return false;
        }
        
        if (_resourceConsumer.Container.IsEmpty)
        {
            _productionBuilding.UpdateStatus(ProductionBuildingStatusType.StopNoConsumption);
            consumptionResources = null;
            return false;
        }

        ResourceType[] consumptionResourcesTypes = _resourceConsumer.Data.ConsumptionResourceTypes;

        List<IResource> availableResources = new List<IResource>();

        foreach (var consumptionResourceType in consumptionResourcesTypes)
        {
            if (_resourceConsumer.Container.GetResourceByType(consumptionResourceType, out IResource resource));
            {
                if (resource != null)
                    availableResources.Add(resource);
            }
        }

        if (availableResources.Count == consumptionResourcesTypes.Length)
        {
            consumptionResources = availableResources;
            return true;
        }

        consumptionResources = null;
        return false;
    }
}