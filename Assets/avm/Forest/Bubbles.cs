using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bubbles : MonoBehaviour
{
    float bubbleHealth = 5;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log(" pre drown Value" + Drowning.AirSupplyTime);
            float v = Drowning.AirSupplyTime + bubbleHealth;
            Debug.Log("drowning value" + v);
        }
    }
}
