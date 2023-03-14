using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTimer : MonoBehaviour
{

    public float timeToWait;
    private float currentWaitTime;
    private bool checkTime;
    public GameObject RoboDog;

    void Awake()
    {
        ResetTimer();
    }
    void Update()
    {
        if (checkTime)
        {
            currentWaitTime -= Time.deltaTime;
            if (currentWaitTime < 0)
            {
                TimerFinished();
                checkTime = false;
            }
        }
    }

    public void ResetTimer()
    {
        currentWaitTime = timeToWait;
        checkTime = true;
    }
    void TimerFinished()
    {
        RoboDog.SetActive(false);
    }
}
