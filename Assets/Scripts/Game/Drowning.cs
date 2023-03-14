using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Drowning : MonoBehaviour
{
    public static float AirSupplyTime = 130;
    public static float totalTime = 130;

    private void Update()
    {
        AirSupplyTime -= Time.deltaTime;
        timer(AirSupplyTime);
    }

    void timer(float timeToDisplay)
    {
        float timeRemaining = AirSupplyTime; // 90 seconds remaining
        float percentage = (timeRemaining / totalTime) * 100;
        //Debug.Log("Time remaining as percentage: " + percentage + "%");
        int HealthDecrease = (int)percentage;
        HealthManager.AlexHealth = HealthDecrease;
    }
    }
