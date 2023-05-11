using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public int lives = 3;
    public int medals = 0;
    public int score = 0;

    private void Awake()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("Medals", medals);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Checkpoint", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Lives"))
        {
            lives = PlayerPrefs.GetInt("Lives");
            medals = PlayerPrefs.GetInt("Medals");
            score = PlayerPrefs.GetInt("Score");
            SceneManager.LoadScene(PlayerPrefs.GetInt("Checkpoint"));
        }
    }
}