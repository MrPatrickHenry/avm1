using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleHealth : MonoBehaviour
{

    public AudioClip soundClip; // Drag and drop your sound clip here in Inspector
    private AudioSource audioSource;


    private void Awake()
    {
        // Get the AudioSource from the gameObject
        audioSource = GetComponent<AudioSource>();

        // If there isn't an AudioSource component, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            if (HealthManager.AlexHealth < 100)
            {
                HealthManager.AlexHealth = 100;
                Debug.Log(HealthManager.AlexHealth);
                gameObject.SetActive(false);
                PlaySound();
            }
            else
            {
                gameObject.SetActive(false);

            }



        }

    }


    void PlaySound()
    {
        if (soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning("No soundClip assigned to the BottleHealth script in" + gameObject.name);
        }
    }


}
