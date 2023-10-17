using UnityEngine;

public class ResourceConsumer : MonoBehaviour, IResourceConsumer
{
    [SerializeField] private ResourceConsumerData _data;
    [SerializeField] private ResourceContainer _consumptionContainer;

    public ResourceConsumerData Data => _data;
    public IResourceContainer Container => _consumptionContainer;
    
    public void Initialize()
    {
        _consumptionContainer.Initialize(_data.ConsumptionContainerCapacity);
    }
}