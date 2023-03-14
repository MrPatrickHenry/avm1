using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static int AlexHealth = 100;
    public static int lives = 4;

    [SerializeField]
    TextMeshProUGUI HealthRemaining;

    [SerializeField]
    GameObject GameOVER;

    // Start is called before the first frame update
    void Awake()
    {
        AlexHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(AlexHealth);
        //HealthRemaining.text = AlexHealth.ToString();

        if (AlexHealth == 100)
        {
            HealthRemaining.text = "100%";
        }
        if(AlexHealth <= 0)
        {
            lives -= 1;
            AlexHealth = 100;
            PlayerManager.ReplayLevel();
        }
        if (AlexHealth <= 99)
        {
            string healthString = HealthManager.AlexHealth.ToString();
            string percent = " %";
            HealthRemaining.text = string.Concat(healthString, percent);
        }

        if (lives <= 0)
        {
            //PlayerManager.isGameOver = true;
            //GameOVER.SetActive(true);
        }
        //HealthRemaining.text = AlexHealth.ToString();
    }
}
