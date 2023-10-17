using UnityEngine;

public class ResourceDispenser : MonoBehaviour, IResourceDispenser
{
    [SerializeField] private float _collectInterval = 2f;
    [SerializeField] private float _translateSpeed = 1f;
    private IResourceContainer _selfContainer;
    private IResourceContainer _targetContainer;
    private ResourceCollectArea _interactedCollectArea;
    private bool _isDispensed;
    private float _timer;

    public void Initialize(IResourceContainer container)
    {
        _selfContainer = container;
    }

    private void OnTriggerEnter(Collider other)
    {
        var resourceCollectArea = other.GetComponent<ResourceCollectArea>();

        if (!resourceCollectArea)
            return;

        _interactedCollectArea = resourceCollectArea;
        _targetContainer = resourceCollectArea.Container;
        _isDispensed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        var resourceCollectArea = other.GetComponent<ResourceCollectArea>();

        if (!resourceCollectArea)
            return;

        if (_targetContainer != resourceCollectArea.Container)
            return;

        _timer = 0f;
        _targetContainer = null;
        _isDispensed = false;
    }

    private void Update()
    {
        if (!_isDispensed)
            return;

        _timer += Time.deltaTime;

        if (!(_timer >= _collectInterval))
            return;

        _timer = 0f;
        TryToDispense(_interactedCollectArea.CanCollectedTypes);
    }

    private bool TryToDispense(ResourceType[] canCollectResourceTypes)
    {
        foreach (var t in canCollectResourceTypes)
        {
            if (_selfContainer.GetResourceByType(t, out IResource resource))
            {
                _selfContainer.TranslateToContainer(resource, _targetContainer, _translateSpeed);
                return true;
            }
        }

        return true;
    }
}