using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBottle : MonoBehaviour
{
    public static int healthIncrease = 20;
    public string healthDif;
    private int playersScore;
    public static AudioSource _audioSource;
    private int healthBoost = 20;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Physics2D.IgnoreLayerCollision(7, 7, true);

        if (collision.gameObject.tag == "Player")
        {
            //_audioSource.Play();
            Debug.Log("Power up !");
            HealthManager.AlexHealth += healthBoost;
        }
    }
}
