using UnityEngine;

public class ResourceDispenseArea : MonoBehaviour
{
    [SerializeField] private ResourceContainer _container;

    public IResourceContainer Container => _container;
}