using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTImer : MonoBehaviour
{
    public static float timeRemaining = 120;
    [SerializeField] TextMeshProUGUI timeText;
    public bool timerIsRunning = false;
    [SerializeField] TextMeshProUGUI GameOVER;
    [SerializeField] TextMeshProUGUI livesRemaining;
    public int lives;
    public static AudioSource _audioSource;
    [SerializeField]
    public AudioClip _pendingDoom;

    private void Start()
    {
        timerIsRunning = true;
        lives = 4;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has ended");
                timeRemaining = 0;
                timerIsRunning = false;
				GameOVER.gameObject.SetActive(true);
				lives = lives -1;
				Debug.Log(lives);
				livesRemaining.text = lives.ToString();

            }
            if(timeRemaining <= 10)
            {

                //CO_Routine NEEDED
                timerIsRunning = false;

                GetComponent<AudioSource>().clip = _pendingDoom;
                _audioSource.Play();
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

                //for NOW! TODO
                timeText.gameObject.SetActive(false);
                

            }

        }
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
