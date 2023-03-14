using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleHealth : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            HealthManager.AlexHealth = 100;
            Debug.Log(HealthManager.AlexHealth);
            gameObject.SetActive(false);
        }
        
    }



}
