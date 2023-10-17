using System.Collections.Generic;

public class ResourceProducerWithConsumptionBehaviour : IResourceProducerBehaviour
{
    private StateMachine _stateMachine;
    private ResourceProducerIdleState _idleState;
    private ResourceProducerCheckingWithConsumptionState _checkingNoConsumptionState;
    private ResourceProducerProduceWithConsumptionState _produceState;
    
    public void InitializeStateMachine(IProductionBuilding productionBuilding, IResourceProducer resourceProducer, IResourceFactory resourceFactory, 
        IResourceConsumer resourceConsumer, IResourceContainer factoryContainer)
    {
        _stateMachine = new StateMachine();
        _idleState = new ResourceProducerIdleState(resourceProducer);
        _checkingNoConsumptionState = new ResourceProducerCheckingWithConsumptionState(this, resourceProducer, resourceConsumer, productionBuilding);
        _produceState = new ResourceProducerProduceWithConsumptionState(this, resourceProducer, resourceConsumer, factoryContainer, resourceFactory);
    }

    public void SetIdleState()
    {
        _stateMachine.ChangeState(_idleState);
    }

    public void SetCheckingState()
    {
        _stateMachine.ChangeState(_checkingNoConsumptionState);
    }

    public void SetProductionState(List<IResource> consumptionResources)
    {
        _produceState.SetProduceResources(consumptionResources);
        _stateMachine.ChangeState(_produceState);
    }

    public void UpdateCurrentState()
    {
        _stateMachine.CurrentState?.Update();
    }
}