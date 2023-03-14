using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BadShark : MonoBehaviour
{
    public TextMeshProUGUI livesRemaining;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Alex Killed");
            HealthManager.lives--;
        }
    }
}
