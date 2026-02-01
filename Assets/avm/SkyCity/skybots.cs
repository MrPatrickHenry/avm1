using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybots : MonoBehaviour
{
    public int hitPoints = 8;  // Number of hits the jewel can take
    public AudioClip clinkSound;  // Sound to play when jewel is hit
    private AudioSource audioSource;  // Audio source component to play sounds
    public int scoreValue = 200;  // Score value when jewel is hit

    [SerializeField]
    private Animator myAnimaton;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the jewel is hit by a weapon
        if (collision.gameObject.CompareTag("weaponFired"))
        {
            // Reduce the jewel's hit points
            hitPoints--;

            // Play the clink sound
            if (clinkSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(clinkSound);
            }

            // Add to the player's score
            PlayerManager.Score += scoreValue;

            // If the jewel has no hit points left, destroy it
            if (hitPoints <= 0)
            {

                myAnimaton.Play("BB180Death", 0, 0.0f);

                Destroy(gameObject);
            }
        }

       




    }
}
