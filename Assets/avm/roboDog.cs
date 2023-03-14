using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboDog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT!");
            Destroy(collision.gameObject);
        }

        Physics2D.IgnoreLayerCollision(7, 7, true);


    }
}
