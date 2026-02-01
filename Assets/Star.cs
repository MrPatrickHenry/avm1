using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Star script
public class Star : MonoBehaviour
{
    public int scoreValue = 100;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager.Score += scoreValue;

            Destroy(gameObject);
        }
    }
}
