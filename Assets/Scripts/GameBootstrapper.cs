using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    private ISceneLoader _sceneLoader;

    [Inject]
    public void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void Start()
    {
        _sceneLoader.LoadGameScene();
    }
}
