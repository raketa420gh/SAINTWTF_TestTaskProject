using UnityEngine;

public class ResourceCollectArea : MonoBehaviour
{
    [SerializeField] private ResourceContainer _container;
    [SerializeField] private ResourceType[] _canCollectedTypes;

    public IResourceContainer Container => _container;
    public ResourceType[] CanCollectedTypes => _canCollectedTypes;
}