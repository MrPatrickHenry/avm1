using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Initialize public and static variables

    public static int healthHit = 100;
    public static int lives = 1;
    private int playersScore;
    public static AudioSource _audioSource;
    private int healthBoost = 20;

    // Handle collision events
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the object that collided with the spikes has a "Player" tag
        if (collision.gameObject.tag == "Player")
        {
            // Reduce the player's lives by 1
            HealthManager.lives--;
            Debug.Log(HealthManager.lives);
            // Reset the player's health to 100

            HealthManager.AlexHealth = 100;
            Debug.Log(HealthManager.AlexHealth);
            // Respawn the player at their starting position
            PlayerManager.Respawn();
        }
    }
}
