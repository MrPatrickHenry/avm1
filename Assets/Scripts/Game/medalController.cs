using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class medalController : MonoBehaviour
{
    public int MedalAward = 10;
    private int playersScore;
    public static AudioSource _audioSource;
   public static int medalCounts;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Physics2D.IgnoreLayerCollision(7, 7, true);

        if (collision.gameObject.tag == "Player")
        {
            _audioSource.Play();
            PlayerManager.Score += MedalAward;
            gameObject.SetActive(false);
            medalCounts += 1;
        }
    }

}