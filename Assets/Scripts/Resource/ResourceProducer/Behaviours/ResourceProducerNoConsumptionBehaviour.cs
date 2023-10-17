using System.Collections.Generic;

public class ResourceProducerNoConsumptionBehaviour : IResourceProducerBehaviour
{
    private StateMachine _stateMachine;
    private ResourceProducerIdleState _idleState;
    private ResourceProducerCheckingNoConsumptionState _checkingNoConsumptionState;
    private ResourceProducerProduceNoConsumptionState _produceNoConsumptionState;

    public void InitializeStateMachine(IProductionBuilding productionBuilding, IResourceProducer resourceProducer, IResourceFactory resourceFactory, 
        IResourceConsumer resourceConsumer, IResourceContainer factoryContainer)
    {
        _stateMachine = new StateMachine();
        _idleState = new ResourceProducerIdleState(resourceProducer);
        _checkingNoConsumptionState = new ResourceProducerCheckingNoConsumptionState(resourceProducer, this, productionBuilding);
        _produceNoConsumptionState = new ResourceProducerProduceNoConsumptionState(this, resourceProducer, resourceFactory, factoryContainer, resourceProducer.Container);
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
        _stateMachine.ChangeState(_produceNoConsumptionState);
    }

    public void UpdateCurrentState()
    {
        _stateMachine.CurrentState?.Update();
    }
}