using TMPro;
using UnityEngine;

public class Chronometer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chronometerText;
    public float time;
    public bool gameOver = false;
    private SceneManagerUI sceneManager;

    private void Start()
    {
        gameOver = false;
        sceneManager = FindAnyObjectByType<SceneManagerUI>().GetComponent<SceneManagerUI>();
    }

    private void GameTime()
    {

        if (!gameOver)
        {
            time -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            int timeTenthsOfASecond = Mathf.FloorToInt((time % 1) * 100);
            chronometerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, timeTenthsOfASecond);
        }


        if (time <= 0)
        {
            chronometerText.text = string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            gameOver = true;
            sceneManager.GoToGameOverScreen();

        }
    }

    void Update()
    {
        GameTime();
    }
}
