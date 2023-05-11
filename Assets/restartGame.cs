using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    public void RestartGame()
    {

        HealthManager.AlexHealth = 100;
        HealthManager.lives = 4;
        medalController.medalCounts = 0;
        PlayerManager.Score = 0;
        SceneManager.LoadScene(2); // Replace 1 with the build index of your first scene

    }
}
