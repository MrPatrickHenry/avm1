using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class RobotDogSpaceMode : MonoBehaviour
{
    bool isForwardDown = false;
    public static bool isBackwardDown = false;
    [SerializeField]
    float movementSpeed;
    bool moving;
    private Vector2 capsuleColliderSize;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;

    //// Start is called before the first frame update
    void Start()
    {
        //AlexHealth = 100;
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        capsuleColliderSize = cc.size;

        //savedPlayerPosition = spawnPoint.transform.position;
    }

   // Update is called once per frame
    void Update()
    {



        float xInput = Input.GetAxisRaw("Horizontal");


        if (xInput > 0)
        {
            // Move the player along the x-axis
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0f, 0f);

            // Play the animation on a loop while the player is moving
            if (!moving)
            {
                moving = true;
                           }
        }
        else
        {
            
        }




        if (isForwardDown)
        {
            Debug.Log("Forward Down");
            //rb.AddForce(new Vector2(2 * movementSpeed * Time.deltaTime, 0));
          transform.position += new Vector3(movementSpeed * Time.deltaTime, 0.0f, 0.0f);//player moves backwards
        }

        //while (isBackwardDown)
        //{
        //    StartCoroutine(PlayAnimationLoop());

        //}

        if (isBackwardDown)
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0.0f, 0.0f);//player moves backwards
         }



    }



    public void FarwardButton(bool state)
    {
        isForwardDown = state;
    }


    public void BackwardButton(bool state)
    {
        isBackwardDown = state;
       

    }



}
