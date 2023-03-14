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
    [SerializeField] private string explode = "explosionSkuls";
    [SerializeField] private float timeDelay;

    private void Awake()
    {
        myAnimaton.Play("SkullGloopers");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "playerAlex")
        {
            Debug.Log("Damage Taken!");
            PlayerHelathUpdate = HealthManager.AlexHealth -= glooperDamage;
            Debug.Log(PlayerHelathUpdate);
            //PlayerController.DamageTaken()
            myAnimaton.Play(explode, 0, 0.0f);
            GameObject.Destroy(this);
        }

        if (collision.gameObject.tag == "BottomBar")
        {
            Debug.Log("should explode now");
            myAnimaton.Play("Explosion",0,0.0f);
            Destroy(gameObject, 0.5f);
        }    

    }

}
