using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YetiBallController : MonoBehaviour
{
    public int damage = 12;
    public float moveSpeed = 25f;
    public float speed = 25f;
    [SerializeField]
    public GameObject BossObject;
    public GameObject Boss;
    private Vector2 BossPosition;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    public Rigidbody2D projectile;
    private Vector2 BossPlayerPosition;
    public Transform target;
    public int PlayerHelathUpdate;

    //Pseudo Code
    //1) timer between 3-5 seconds
    //    2) Play animation
    //    3) spawn snowball and throw it
    // 4) manage collisions

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            MoveTowards(target.position);
            //RotateTowards(target.position);
        }
    }

    //3)
    //BossObject.transform.position += new Vector3(moveSpeed, 0.0f, 0.0f);

    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    //4)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Damage Given!");
            PlayerHelathUpdate = HealthManager.AlexHealth -= damage;
            BossPlayerPosition = BossObject.transform.position;
            this.transform.position = BossPlayerPosition;
            //PlayerController.DamageTaken()
        }
    }

}
