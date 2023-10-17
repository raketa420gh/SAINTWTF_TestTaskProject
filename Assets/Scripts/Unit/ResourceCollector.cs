using UnityEngine;

public class ResourceCollector : MonoBehaviour, IResourceCollector
{
    [SerializeField] private float _collectInterval = 2f;
    [SerializeField] private float _translateSpeed = 1f;
    private IResourceContainer _selfContainer;
    private IResourceContainer _targetContainer;
    private bool _isCollected;
    private float _timer;

    public void Initialize(IResourceContainer container)
    {
        _selfContainer = container;
    }

    private void OnTriggerEnter(Collider other)
    {
        var resourceDispenseArea = other.GetComponent<ResourceDispenseArea>();

        if (!resourceDispenseArea)
            return;

        _targetContainer = resourceDispenseArea.Container;
        _isCollected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        var resourceDispenseArea = other.GetComponent<ResourceDispenseArea>();

        if (!resourceDispenseArea)
            return;

        if (_targetContainer != resourceDispenseArea.Container)
            return;

        _timer = 0f;
        _targetContainer = null;
        _isCollected = false;
    }

    private void Update()
    {
        if (!_isCollected)
            return;

        _timer += Time.deltaTime;

        if (!(_timer >= _collectInterval))
            return;

        _timer = 0f;
        TryToCollect();
    }

    private bool TryToCollect()
    {
        if (!_targetContainer.GetLastResource(out IResource translatedResource)) 
            return false;

        _targetContainer.TranslateToContainer(translatedResource, _selfContainer, _translateSpeed);
        return true;
    }
}