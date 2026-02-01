using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class BonusCountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float timeRemaining = 60;

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.Log("Countdown Finished!");
            timeRemaining = 0;
            DisplayTime(timeRemaining);

            // Load scene number 8 when the countdown finishes
            SceneManager.LoadScene(8);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
