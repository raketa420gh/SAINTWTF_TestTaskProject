using UnityEngine;

public interface IResourceContainerView
{
    void Initialize(IResourceContainer container);
    
    Transform Point { get; }
}
