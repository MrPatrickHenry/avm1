using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybarCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("should explode now");
            // myAnimaton.Play("Explosion",0,0.0f);
            Destroy(gameObject, 0.5f);
        }    

    }



}
