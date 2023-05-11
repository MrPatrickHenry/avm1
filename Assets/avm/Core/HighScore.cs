using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI ScoreText;
    [SerializeField]
    TextMeshProUGUI Remainingtime;
    [SerializeField]
    TextMeshProUGUI Medals;
    [SerializeField]
    TextMeshProUGUI NEWSCORE;

    public static void  UpdateHighScore()
    {
        int curentScore;
        int timeleft;
        int medalsgot;

        medalsgot = medalController.medalCounts;
        curentScore = PlayerManager.Score;
        timeleft = (int)CountdownTimer.timeRemaining;
        GameData.highScore = medalsgot + curentScore * timeleft;

        Debug.Log(GameData.highScore);
    }

}
