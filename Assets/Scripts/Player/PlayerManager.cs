using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//PATRICK CODE

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    [SerializeField] public static GameObject spawnPoint;
    public static Vector2 savedPlayerPosition;
    public static int Score;
   
    [SerializeField]
    public static TextMeshProUGUI ScoreText;
    [SerializeField]
    public static TextMeshProUGUI HealthTextUI;
    [SerializeField]
    public static TextMeshProUGUI LivesTextUI;
    private void Awake()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        //UpdateUIs();
    }

    //public void UpdateUIs()
    //{

    //    ScoreText.text = Score.ToString();
    //    HealthTextUI.text = HealthManager.AlexHealth.ToString();
    //    LivesTextUI.text = HealthManager.lives.ToString();

    //}

    public static void Respawn()
    {
        //savedPlayerPosition = spawnPoint.transform.position;
        //gameObject.transform.position = savedPlayerPosition;
    }

    public static void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void PauseGame()
    {
        Time.timeScale = 0;
        //pauseMenuScreen.SetActive(true);
    }
    public static void ResumeGame()
    {
        Time.timeScale = 1;
        //pauseMenuScreen.SetActive(false);
    }
    public static void GoToMenu()
    {
        //SceneManager.LoadScene("Menu");
    }
}
