using UnityEngine;
using Zenject;

public class InputHandlerInstaller : MonoInstaller
{
    [SerializeField] private JoystickInputHandler _inputHandlerInstance;

    public override void InstallBindings() => 
        Bind();

    private void Bind()
    {
        BindResourceFactory();
    }

    private void BindResourceFactory()
    {
        Container
            .Bind<IInputHandler>()
            .FromInstance(_inputHandlerInstance)
            .AsSingle()
            .NonLazy();
    }
}