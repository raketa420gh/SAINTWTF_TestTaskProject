using UnityEngine;

[CreateAssetMenu(order = 52, menuName = "ResourceProducer", fileName = "ResourceProducerData")]

public class ResourceProducerData : ScriptableObject
{
    [SerializeField] private ResourceType _productionResourceType;
    [SerializeField] private int _productionContainerCapacity = 10;
    [SerializeField] private float _productionPeriod = 3f;
    [SerializeField] private float _checkingInterval = 1f;
    [SerializeField] private float _translateAnimationTime = 0.25f;

    public ResourceType ProductionResourceType => _productionResourceType;
    public int ProductionContainerCapacity => _productionContainerCapacity;
    public float ProduceTime => _productionPeriod;
    public float CheckingInterval => _checkingInterval;
    public float TranslateAnimationTime => _translateAnimationTime;
}