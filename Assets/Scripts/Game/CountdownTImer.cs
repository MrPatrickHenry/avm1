using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField]
    public float timeRemainingLevel = 120;
    [SerializeField] private TextMeshProUGUI timeText;
    public bool timerIsRunning = false;
    [SerializeField] private TextMeshProUGUI gameOver;
    [SerializeField] private TextMeshProUGUI livesRemaining;
    public int lives;
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _pendingDoom;
    private bool _isAudioPlaying = false;
    public static float timeRemaining;
    private void Start()
    {
        timeRemaining = timeRemainingLevel;
        timerIsRunning = true;
        lives = 4;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                HealthManager.AlexHealth = 0;
            }
            else if (timeRemaining <= 10 && !_isAudioPlaying)
            {
                _isAudioPlaying = true;
                _audioSource.clip = _pendingDoom;
                _audioSource.Play();
            }

            timeText.color = timeRemaining < 30 ? Color.red : Color.white;
            DisplayTime(timeRemaining);
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}