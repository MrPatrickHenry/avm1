    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomAttack : MonoBehaviour
{
    private Rigidbody2D VenomRB;
    public int glooperDamage = 5;

    private float venomSpitSpeed;

    private void Start()
    {
        Object.Destroy(gameObject, 3.0f);
    }


    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("missed!");
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }


        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Attacked!");
            Destroy(gameObject);
            HealthManager.AlexHealth -= 10;
        }
    }
}