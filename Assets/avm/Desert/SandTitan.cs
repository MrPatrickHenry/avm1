using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SandTitan : MonoBehaviour
{

    public int BossHealth = 100;
    public int Health = 100;
    public int DeathLevel = 0;
    [SerializeField]
    private TextMeshProUGUI TMPtext;
    private int SpiderScores = 300;
    private int puckDamage = 10;
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
    private Animator TitanAnimator;
    [SerializeField]
    public TextMeshProUGUI bosshealthText;
    public GameObject portalExit;

    void Update()
    {
        if (DeathLevel == BossHealth)
        {
            playing = true;
            TitanAnimator.Play("SandTitanDeath", 0, 0);
            Destroy(gameObject);
            portalExit.SetActive(true);
        }

        //TitanAnimator.Play("SandTitans",0,0);
    }

    private void Start()
    {
        //VenomRB = GetComponent<Rigidbody2D>();
        //InvokeRepeating("spit", 2.0f, Random.Range(3, 8));
    }

    void spit()
    {
        Debug.Log("Titan Attack");
        //SpiderAnimation.Play("QueenAttack", 0, 0);
        Debug.Log("Titan Attacked");

        Rigidbody2D instance = Instantiate(projectile);

        instance.velocity = new Vector3(Random.Range(-1000.0f, -1500f) * Time.deltaTime, 0, 0);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("HIT!");
            //Destroy(collision.gameObject);
            HealthManager.AlexHealth = -32;
        }


        if (collision.gameObject.tag == "weaponFired")
        {
            //Destroy(collision.gameObject);
            SpiderScores = SpiderScores + SpiderScores;
            TMPtext.text = SpiderScores.ToString();
            BossHealth = BossHealth - puckDamage;
            bosshealthText.text = BossHealth.ToString();
            //SpiderAnimation.Play("hur", 0, 0);
            Debug.Log("boss level: " + BossHealth);
        }
    }
}
