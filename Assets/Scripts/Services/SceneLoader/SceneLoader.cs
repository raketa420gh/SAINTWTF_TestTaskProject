using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    private const string GameScene = "GameScene";

    public void LoadGameScene()
        => SceneManager.LoadScene(GameScene);
}