using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Patrick
public class PlayerCollision : MonoBehaviour
{
    public int glooperDamage = 5;
    public int FatalDagme = 100;
    public int healthUpdate;
    [SerializeField]
    private Animator myAnimaton;
    float bubbleHealth = 5;

    private bool playing;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(7, 7);

        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("glooper attacked me");
            myAnimaton.Play("AlexanderDamaged", 0, 0.0f);
            HealthManager.AlexHealth -= glooperDamage;
           StartCoroutine(GetHurt());
        }

        if (collision.transform.tag == "Bubble")
        {
            Debug.Log("Pre drown Value" + Drowning.AirSupplyTime);
            //HealthManager.AlexHealth += 5;
           Drowning.totalTime += bubbleHealth;
            Debug.Log("drowning value" + Drowning.totalTime);
            GameObject.Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "Spikes")
        {
            _ = HealthManager.AlexHealth - FatalDagme;
        }

        if (collision.gameObject.tag == "BossAttack")
        {
            Debug.Log("Attacked!");
            //Destroy(collision.gameObject);
            HealthManager.AlexHealth -= 10;
            StartCoroutine(GetHurt());
        }

    }
    IEnumerator GetHurt()
    {
        playing = true;
        myAnimaton.Play("AlexanderDamaged", 0, 0.0f);
        yield return new WaitForSeconds(1);
    }
}
