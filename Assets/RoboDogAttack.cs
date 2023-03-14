using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboDogAttack : MonoBehaviour
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
            //Debug.Log("Damage Taken!");
            //PlayerHelathUpdate = PlayerController.AlexHealth -= glooperDamage;
            //Debug.Log(PlayerHelathUpdate);
            //PlayerController.damgeUpdate = PlayerHelathUpdate.ToString() + "%";
            ////PlayerController.DamageTaken()
        }
    }
}
