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
    private GameObject restartButton;
    private TextMeshProUGUI medalCount;

    [SerializeField]
    private GameObject gameOver;

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
        restartButton = GameObject.Find("Restart");
        medalCount = GameObject.Find("Medatext").GetComponent<TextMeshProUGUI>();

        gameOver.SetActive(false);
        hiScore.text = GameData.highScore.ToString();
        HealthManager.AlexHealth = 100;
    }

    private void Update()
    {
        lives.text = HealthManager.lives.ToString();
        healthRemaining.text = $"{HealthManager.AlexHealth} %";
        bossText.text = queenSpider.BossHealth.ToString();
        medalCount.text = medalController.medalCounts.ToString();

        if (HealthManager.lives == 0 && !isDead)
        {
            isDead = true;
            gameOver.SetActive(true);
            Debug.Log("DEAD");
            PlayerManager.PauseGame();
            player.SetActive(false);
        }

        healthRemaining.color = HealthManager.AlexHealth < 30 ? Color.red : Color.white;
        scoreText.text = PlayerManager.Score.ToString();
    }
}
