using UnityEngine;
using Zenject;

public class FactoryInstaller : MonoInstaller
{
    [SerializeField] private ResourceFactory _resourceFactoryInstance;

    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        BindResourceFactory();
    }

    private void BindResourceFactory()
    {
        Container
            .Bind<IResourceFactory>()
            .FromInstance(_resourceFactoryInstance)
            .AsSingle()
            .NonLazy();
    }
}