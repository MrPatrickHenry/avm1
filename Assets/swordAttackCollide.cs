using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttackCollide : MonoBehaviour
{

    bool isAttackDown = false;
    public static int damage = 5;
    public int points = 100;
    public float speed = 4.5f;

    public void attack(bool state)
    {
        isAttackDown = state;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT!");
            PlayerManager.Score += points;
            Debug.Log(PlayerManager.Score);
            // this.transform.position = PlayerManager.savedPlayerPosition;
            Handheld.Vibrate();

             Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BossAttack")
        {
            Handheld.Vibrate();

            // Destroy(collision.gameObject);
        }


        if (collision.gameObject.tag == "queenSpiderboss")
        {
            Handheld.Vibrate();
            Debug.Log("HIT!");
            PlayerManager.Score += points;

        }
    }
}
