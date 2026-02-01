using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIUpdates : MonoBehaviour
{
    private TextMeshProUGUI healthRemaining;
    private TextMeshProUGUI scoreText;
    private GameObject player;
    private TextMeshProUGUI bossText;
    private TextMeshProUGUI hiScore;
    //private GameObject restartButton;
    private TextMeshProUGUI medalCount;
    private int prevMedalCount = 0;

    //[SerializeField]
    //private GameObject gameOver;

    [SerializeField]
    private TextMeshProUGUI lives;

    public bool isDead;

    private void Start()
    {
        healthRemaining = GameObject.Find("Damage").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        //lives = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("playerAlex Variant");
        bossText = GameObject.Find("BossHealthText").GetComponent<TextMeshProUGUI>();
        hiScore = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        //restartButton = GameObject.Find("Restart");
        medalCount = GameObject.Find("Medatext").GetComponent<TextMeshProUGUI>();

        //gameOver.SetActive(false);
        hiScore.text = GameData.highScore.ToString();
        HealthManager.AlexHealth = 100;
        GameOverManager.lastSceneIndex = SceneManager.GetActiveScene().buildIndex; // save the current scene index

    }

    private void Update()
    {
        lives.text = HealthManager.lives.ToString();
        healthRemaining.text = $"{HealthManager.AlexHealth} %";
        bossText.text = queenSpider.BossHealth.ToString();
        //medalCount.text = medalController.medalCounts.ToString();

        // Check if medal count has reached a multiple of 100
        if (medalController.medalCounts / 100 > prevMedalCount / 100)
        {
            // Increase lives by 1
            HealthManager.lives += 1;
        }
        // Update previous medal count
        prevMedalCount = medalController.medalCounts;



        if (HealthManager.lives == 0 && !isDead)
        {
            isDead = true;
            //gameOver.SetActive(true);
            Debug.Log("DEAD");
            PlayerManager.PauseGame();
            SceneManager.LoadScene(24);
        }

        healthRemaining.color = HealthManager.AlexHealth < 30 ? Color.red : Color.white;
        scoreText.text = PlayerManager.Score.ToString();
    }
}
