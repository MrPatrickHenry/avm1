using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    public float speed = 1.0f;
    public int points = 10;
    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            target = new Vector2(player.position.x, player.position.y);
            Vector2 direction = target - (Vector2)transform.position;
            GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            // Add points to the player's score
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Subtract points from the player's score
            Destroy(gameObject);
        }
    }
}
