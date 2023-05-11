using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanBossMovement : MonoBehaviour
{
    //public float moveSpeed = 1.0f;
    //public float stepDistance = 2.0f;
    //public float waitTime = 0.5f;
    //public CameraShake cameraShake;
    //private bool isMovingRight = true; // direction of movement
    //private float nextStepTime;

    public float speed = 5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(MoveSandTitan());
    }

    IEnumerator MoveSandTitan()
    {
        while (true)
        {
            // Move to the right for 10 seconds
            float moveTime = 0f;
            while (moveTime < 10f)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                moveTime += Time.deltaTime;
                yield return null;
            }

            // Flip the sprite renderer
            spriteRenderer.flipX = true;

            // Move to the left for 10 seconds
            moveTime = 0f;
            while (moveTime < 10f)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                moveTime += Time.deltaTime;
                yield return null;
            }

            // Flip the sprite renderer back
            spriteRenderer.flipX = false;
        }
    }



    //private void Start()
    //{
    //    //nextStepTime = Time.time + waitTime;
    //    rb = GetComponent<Rigidbody2D>();

    //}

    ////private void Update()
    ////{
    ////    if (Time.time > nextStepTime)
    ////    {
    ////        transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime); // move the sprite to the left
    ////        nextStepTime = Time.time + waitTime;
    ////        // Trigger camera shake event here
    ////        cameraShake.Shake();

    ////    }


    ////}


    //private void FixedUpdate()
    //{
    //    // Move the SandTitan to the right at a slow pace
    //    rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    //}

}

