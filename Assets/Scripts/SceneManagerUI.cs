using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerUI : MonoBehaviour 
{

    private static int currentLevel;

    private readonly string[] levelScenes = new string[]
    {
        "Nivel1_whiteblocking", "Nivel2_TEST", "Nivel3_TEST"
    };

    public void GoToMainMenuScreen()
    {
        currentLevel = 0;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void GoToStartGame() => SceneManager.LoadScene(levelScenes[0]);
    public void GoToGameOverScreen() => SceneManager.LoadScene("Game Over");
    public void GoToVictoryScreen() => SceneManager.LoadScene(currentLevel >= levelScenes.Length - 1 ? "FinalVictory" : "Victory");
    public void GoToNextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(levelScenes[currentLevel]);
    }


    public void GoToRetryLevel() => SceneManager.LoadScene(levelScenes[currentLevel]);
    public void GoToExitGame() => Application.Quit();
    

}
