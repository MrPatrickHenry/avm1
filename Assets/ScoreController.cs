using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class GameData
{
    public static int highScore = 0;
}


public class ScoreController : MonoBehaviour
{
   
    // Call this function at the end of each scene to update the high score
    public static void UpdateHighScore()
    {
        int timeRemaining = int.Parse(Mathf.RoundToInt(CountdownTImer.timeRemaining).ToString());
        int score = PlayerManager.Score;
        int scoreWithTime = (int)(score + (timeRemaining * 10));
        if (scoreWithTime > GameData.highScore)
        {
            GameData.highScore = scoreWithTime;
        }
    }
}
