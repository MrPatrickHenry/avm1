using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GolemSand : MonoBehaviour
{
    public int BossHealth = 100;
    public int Health = 100;
    public int DeathLevel = 0;
    [SerializeField]
    private TextMeshProUGUI TMPtext;
    private int SpiderScores = 300;
    private int puckDamage = 20;
    [SerializeField]
    private GameObject venom;
    private Vector2 savedPlayerPosition;
    [SerializeField]
    public float venomSpitSpeed = -1200;
    [SerializeField]
    private Rigidbody2D VenomRB;
    private float thrust = 1f;
    // Update is called once per frame
    public Rigidbody2D projectile;
    public bool playing;
    [SerializeField]
    private Animator SandGolemAnimation;

    void Update()
    {
        if (DeathLevel == BossHealth)
        {
            playing = true;
            //need SandDestructionAnimation
            //SpiderAnimation.Play("explodeSpiderQueen", 0, 0);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        VenomRB = GetComponent<Rigidbody2D>();
        InvokeRepeating("spit", 2.0f, Random.Range(3, 8));
    }

    void spit()
    {
        Debug.Log("Queen Attack");
        //need sand attack
        //SpiderAnimation.Play("QueenAttack", 0, 0);
        Debug.Log("Queen Attacked");

        Rigidbody2D instance = Instantiate(projectile);

        instance.velocity = new Vector3(Random.Range(-1000.0f, -1500f) * Time.deltaTime, 0, 0);

}

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("HIT!");
            //Destroy(collision.gameObject);
            HealthManager.AlexHealth = -20;
        }


        if (collision.gameObject.tag == "weaponFired")
        {
            //Destroy(collision.gameObject);
            SpiderScores = SpiderScores + SpiderScores;
            TMPtext.text = SpiderScores.ToString();
            BossHealth = BossHealth - puckDamage;
            //need sand golem hurt animation
            //SpiderAnimation.Play("hur", 0, 0);
            Debug.Log("boss level: " + BossHealth);
        }
    }
}
