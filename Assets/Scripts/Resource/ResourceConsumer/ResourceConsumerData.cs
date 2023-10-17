using UnityEngine;

[CreateAssetMenu(order = 52, menuName = "ResourceConsumer", fileName = "ResourceConsumerData")]

public class ResourceConsumerData : ScriptableObject
{
    [SerializeField] private ResourceType[] _consumptionResourceTypes;
    [SerializeField] private int _consumptionContainerCapacity = 10;

    public ResourceType[] ConsumptionResourceTypes => _consumptionResourceTypes;
    public int ConsumptionContainerCapacity => _consumptionContainerCapacity;
}