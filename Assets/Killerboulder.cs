using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killerboulder : MonoBehaviour
{
    [SerializeField]
    public float XrotationsPerMinute = 0f;
    [SerializeField]
    public float YrotationsPerMinute = 0f;
    [SerializeField]
    public float ZrotationsPerMinute = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(XrotationsPerMinute, YrotationsPerMinute, ZrotationsPerMinute);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            // Reduce the player's lives by 1
            HealthManager.lives--;
            Debug.Log(HealthManager.lives);
            // Reset the player's health to 100
            HealthManager.AlexHealth = 100;
            Debug.Log(HealthManager.AlexHealth);
            // Respawn the player at their starting position
            PlayerManager.ReplayLevel();
        }
    }


}
