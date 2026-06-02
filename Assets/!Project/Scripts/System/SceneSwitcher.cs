using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private enum ScenesName
    {
        GameScene,
        LoseScene,
        StartScene,
    }
    public void LoanMainMenu()
    {
        SceneManager.LoadScene(ScenesName.StartScene.ToString());
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(ScenesName.GameScene.ToString());
    }
    public void LoadFailedScene()
    {
        SceneManager.LoadScene(ScenesName.LoseScene.ToString());
    }
}
