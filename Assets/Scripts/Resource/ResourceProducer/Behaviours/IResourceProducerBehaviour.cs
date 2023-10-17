using System.Collections.Generic;

public interface IResourceProducerBehaviour
{
    void InitializeStateMachine(IProductionBuilding productionBuilding, IResourceProducer resourceProducer, IResourceFactory resourceFactory, 
        IResourceConsumer resourceConsumer, IResourceContainer factoryContainer);
    
    void SetIdleState();
    void SetCheckingState();
    void SetProductionState(List<IResource> consumptionResources);
    void UpdateCurrentState();
}