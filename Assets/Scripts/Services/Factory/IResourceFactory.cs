public interface IResourceFactory
{
    IResource CreateResource(ResourceType type, IResourceContainer container);
}