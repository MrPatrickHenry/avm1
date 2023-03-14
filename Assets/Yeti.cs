using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Yeti : MonoBehaviour
{
    public int BossHealth = 100;
    public int Health = 100;
    public int DeathLevel = 0;
    [SerializeField]
    private TextMeshProUGUI TMPtext;
    private int BossScores = 300;
    private int puckDamage = 20;
    public TextMeshProUGUI bosshealthText;

    // Update is called once per frame
    void Update()
    {
        if (Health == DeathLevel)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerAlex")
        {
            Debug.Log("HIT!");
            //Destroy(collision.gameObject);
            Debug.Log(CharacterController.AlexHealth -= 15);
        }

        if (collision.gameObject.tag == "weaponFired")
        {
            Debug.Log("Boss HIT!");
            //Destroy(collision.gameObject);
            BossScores = BossScores + BossScores;
            TMPtext.text = BossScores.ToString();
            BossHealth = BossHealth - puckDamage;
            Debug.Log("Hit effect" + BossHealth);
            Debug.Log(BossHealth);
        }
    }

}
