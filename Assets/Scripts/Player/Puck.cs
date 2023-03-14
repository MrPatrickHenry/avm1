using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puck : MonoBehaviour
{

    bool isAttackDown = false;
    public int damage = 5;
    public int points = 100;
    public float speed = 4.5f;

    public void attack(bool state)
    {
        isAttackDown = state;
    }
    private void Start()
    {
        Object.Destroy(gameObject, 2.0f);
    }

    private void Update()
    {
        if (CharacterController.isBackwardDown)
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }
        else
        {
            transform.position += transform.right * Time.deltaTime * speed;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT!");
            PlayerManager.Score += points;
            Debug.Log(PlayerManager.Score);
            this.transform.position = PlayerManager.savedPlayerPosition;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BossAttack")
        {
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.tag == "queenSpiderboss")
        {
            Debug.Log("HIT!");
            PlayerManager.Score =+ points;
        }
    }
}
