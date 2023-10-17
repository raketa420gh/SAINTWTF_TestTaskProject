using UnityEngine;
using Zenject;

[RequireComponent(typeof(ResourceProducer))]

public class ProductionBuildingNoConsumption : ProductionBuilding
{
    [SerializeField] private bool _produceAtStart = true;
    private IResourceFactory _resourceFactory;
    private IResourceProducer _resourceProducer;

    [Inject]
    public void Construct(IResourceFactory resourceFactory)
    {
        _resourceFactory = resourceFactory;
    }

    protected override void Awake()
    {
        _resourceProducer = GetComponent<IResourceProducer>();
        _resourceProducer.Initialize(this, _resourceFactory, new ResourceProducerNoConsumptionBehaviour(), null);

        base.Awake();
    }

    private void Start()
    {
        if (_produceAtStart)
            _resourceProducer.StartProduce();
    }
}