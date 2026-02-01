using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Button retryButton;
    public Button autoRetryButton;
    public Text gameOverText;
    public static int lastSceneIndex;
    private float healthResetValue = 100f;
    private int livesResetValue = 3;
    private int medalsResetValue = 0;
    private int scoreResetValue = 0;
    private int highScoreResetValue = 0;

    private void Start()
    {
        retryButton.onClick.AddListener(RetryGame);
        //autoRetryButton.onClick.AddListener(AutoRetryGame);
        //gameOverText.text = "Game Over";
        //lastSceneIndex = SceneManager.GetActiveScene().buildIndex; // save the current scene index
        AutoRetryGame();
    }

    public void RetryGame()
    {
        // Reset game parameters
        HealthManager.lives = 3;
        HealthManager.AlexHealth = 100;

        // Load the first scene
        SceneManager.LoadScene(lastSceneIndex);
    }

    public void AutoRetryGame()
    {
        // Reset the player's stats
        HealthManager.lives = 3;
        HealthManager.AlexHealth = 100;
        medalController.medalCounts = 0;
        PlayerManager.Score = 0;
        GameData.highScore = 0;

        // Start the coroutine to auto retry the game
        StartCoroutine(AutoRetryCoroutine());
    }

    private IEnumerator AutoRetryCoroutine()
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene(2); // change this to load your first scene
    }


}
