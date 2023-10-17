using System;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceContainer
{
    event Action<IResourceContainer> OnUpdated;
    event Action<IResource, IResourceContainer> OnTranslated;

    IResourceContainerView View { get; }
    List<IResource> Resources { get; }
    bool IsFull { get; }
    bool IsEmpty { get; }
    bool IsAvailable { get; }
    Transform Point { get;}

    void Initialize(int capacity);
    bool Add(IResource resource);
    void Remove(IResource resource);
    void Clear();
    bool GetResourceByType(ResourceType type, out IResource resource);
    bool GetLastResource(out IResource resource);
    void TranslateToContainer(IResource resource, IResourceContainer container, float time);
}