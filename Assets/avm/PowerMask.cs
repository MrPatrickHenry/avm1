using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMask : MonoBehaviour
{
    public string maskName;
    private bool powerMaskActive = false;
    private float powerMaskDuration = 10.0f; // duration of power mask in seconds
    private float powerMaskTimer = 0.0f; // timer for power mask


    void Update()
    {
        // check if power mask is active
        if (powerMaskActive)
        {
            // update timer
            powerMaskTimer += Time.deltaTime;

            // check if power mask duration has expired
            if (powerMaskTimer >= powerMaskDuration)
            {
                // power mask duration has expired, set power mask to inactive and reset timer
                powerMaskActive = false;
                powerMaskTimer = 0.0f;
            }
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (maskName)
            {
                case "Blue":
                    // Add code to give the player the ability to fly
                    break;
                case "Pink":
                    // Add code to give the player the ability to jump higher
                    break;
                case "Yellow":
                    // Add code to heal the player's health
                    break;
                // Add more cases for each mask type and its associated ability
                default:
                    // No ability for this mask
                    break;
            }

            // Destroy the power mask game object after the player has collided with it
            Destroy(gameObject);
        }
    }
}
