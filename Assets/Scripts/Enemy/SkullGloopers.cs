using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkullGloopers : MonoBehaviour

{

    public int glooperDamage = 34;
    private int PlayerHelathUpdate;
    public float speed = 1f;
    [SerializeField] private Animator myAnimaton;
    [SerializeField] private string explode = "Explosion";
    [SerializeField] private float timeDelay;

    private void Awake()
    {
        myAnimaton.Play("SkullGloopers");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHelathUpdate = HealthManager.AlexHealth -= glooperDamage;
            //PlayerController.DamageTaken()
            myAnimaton.Play(explode, 0, 0.0f);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BottomBar")
        {
            myAnimaton.Play("Explosion",0,0.0f);
            Destroy(gameObject, 0.5f);
        }    

    }

}
