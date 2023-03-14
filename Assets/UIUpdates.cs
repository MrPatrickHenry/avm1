using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIUpdates : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI HealthRemaining;

    [SerializeField]
    TextMeshProUGUI ScoreText;

    [SerializeField]
    TextMeshProUGUI lives;
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject GameOVER;


    [SerializeField]
    TextMeshProUGUI bossText;

    [SerializeField] public
    TextMeshProUGUI HiScore;

    [SerializeField]
    GameObject restartBUtton;


    private void Start()
    {
        GameOVER.SetActive(false);
        HiScore.text = GameData.highScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        string healthString = HealthManager.AlexHealth.ToString();
        string percent = " %";

        lives.text = HealthManager.lives.ToString();
        HealthRemaining.text = string.Concat(healthString, percent);
        bossText.text = queenSpider.BossHealth.ToString();



        if (HealthManager.lives == 0)
        {
            GameOVER.SetActive(true);

            Debug.Log("DEAD");

            PlayerManager.PauseGame();
            player.SetActive(false);
        }
        ScoreText.text = PlayerManager.Score.ToString();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1); // Replace 1 with the build index of your first scene
    }
}
