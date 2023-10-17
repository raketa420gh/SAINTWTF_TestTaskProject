using UnityEngine;

public interface IResource
{
    ResourceType Type { get; }
    Transform Transform { get; }

    void Initialize(ResourceData data);
    void Destroy();
    void Pickup(IResourceContainer container);
}