using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSprite : MonoBehaviour
{
    public float moveSpeed = 20f; // speed of movement
    private bool isMovingRight = true; // direction of movement

    void Update()
    {
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // move the sprite to the right
            transform.localScale = new Vector2(1, 1); // set the scale to normal
        }
        else
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime); // move the sprite to the left
            transform.localScale = new Vector2(-1, 1); // flip the sprite horizontally
        }

        if (transform.position.x >= 20f) // if the sprite has reached the right edge
        {
            isMovingRight = false; // change direction to left
        }
        else if (transform.position.x <= -20f) // if the sprite has reached the left edge
        {
            isMovingRight = true; // change direction to right
        }
    }
}
