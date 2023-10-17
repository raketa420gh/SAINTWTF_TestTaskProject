using UnityEngine;
using Zenject;

public class ResourceFactory : MonoBehaviour, IResourceFactory
{
    [SerializeField] private ResourceData _resourceData1;
    [SerializeField] private ResourceData _resourceData2;
    [SerializeField] private ResourceData _resourceData3;
    [SerializeField] private string _resourcePrefabPath = "Prefabs/Resource";
    private IAssetProvider _assetProvider;

    [Inject]
    public void Construct(IAssetProvider assetProvider) => 
        _assetProvider = assetProvider;

    public IResource CreateResource(ResourceType type, IResourceContainer container)
    {
        var path = _resourcePrefabPath;
        GameObject go = _assetProvider.Instantiate(path, Vector3.zero);
        IResource resource = go.GetComponent<IResource>();
        resource.Pickup(container);

        switch (type)
        {
            case ResourceType.Ore1:
                resource.Initialize(_resourceData1);
                break;
            case ResourceType.Ore2:
                resource.Initialize(_resourceData2);
                break;
            case ResourceType.Ore3:
                resource.Initialize(_resourceData3);
                break;
        }

        return resource;
    }
}