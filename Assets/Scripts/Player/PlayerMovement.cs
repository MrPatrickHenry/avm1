using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    [SerializeField]
    private float movementSpeed = 2f;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float slopeCheckDistance;
    [SerializeField]
    private float maxSlopeAngle;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private PhysicsMaterial2D noFriction;
    [SerializeField]
    private PhysicsMaterial2D fullFriction;
    bool isGrounded = true;
    bool isJumpDown = false;
    private float xInput;
    private float slopeDownAngle;
    private float slopeSideAngle;
    private float lastSlopeAngle;
    private bool isOnSlope;
    private bool isJumping;
    private bool canWalkOnSlope;
    private bool canJump;
    private Vector2 newForce;
    private Vector2 capsuleColliderSize;
    private int facingDirection = 1;
    private Vector2 slopeNormalPerp;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;

    //Animation and Sounds
    [SerializeField]
    public Animator myAnimaton;
    public bool playing = false;

    //UI Controls
    bool isAttackDown = false;

    //configs for controlls
    public float forwardSpeed;
    public float backwardSpeed;
    public float AttackSpeed;
    public float puckSpeed;
    bool isForwardDown = false;
    bool isBackwardDown = false;
    bool isRoboDogButtonDown = false;
    public string playerAnimation = "AlexanderRemastered";
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        capsuleColliderSize = cc.size;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        //myAnimaton.Play("Swimming",0,0);
        checkForSwimming();
    }

    public void FarwardButton(bool state)
    {
        isForwardDown = state;
    }

    void checkForSwimming()
    {
        if (sceneName == "2-2 water")
        {
            //TODO: swimming lessons
            //playerAnimation = "Swimming";
        }
        else
        {
            //This should be happeing.
            //playerAnimation = "default";
        }
    }

    private void Update()
    {
       
        if (isForwardDown)
        {
            //rb.AddForce(new Vector2(2 * movementSpeed * Time.deltaTime, 0));

            transform.position += new Vector3(movementSpeed * 4 * Time.deltaTime, movementSpeed * 4 * Time.deltaTime, 0.0f);//player moves backwards
            playing = true;
            //myAnimaton.Play("Swimming", 0, 0);
            //myAnimaton.SetBool("Bool", true);

        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (rb.velocity.y <= 0.0f)
        {
            isJumping = false;
        }

        if (isGrounded && !isJumping && slopeDownAngle <= maxSlopeAngle)
        {
            canJump = true;
        }
    }

    public void Forward()
    {
        isForwardDown = true;
        rb.AddForce(transform.up * 9, ForceMode2D.Impulse);
        rb.AddForce(transform.right * 18, ForceMode2D.Impulse);

        //transform.position += new Vector3(movementSpeed * Time.deltaTime, 0.0f, 0.0f);
        playing = true;
        myAnimaton.SetTrigger("Active");
        myAnimaton.Play(playerAnimation, 0, 0.0f);
    }

    public void SwimSpaceForward()
    {
        //transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0.0f, 0.0f);//player moves backwards
        //rb.AddForce(transform.right * 9, ForceMode2D.Impulse); playing = true;

        transform.position += new Vector3(movementSpeed * Time.deltaTime, movementSpeed * Time.deltaTime, 0.0f);
        playing = true;
        myAnimaton.SetTrigger("Active");
        myAnimaton.Play("Swimming", 0, 0.0f);
    }

    public void upwards()
    {
        rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
        playing = true;
        myAnimaton.SetTrigger("Active");
        myAnimaton.Play("Swimming", 0, 0.0f);
    }
    public void down()
    {
        transform.position += new Vector3(0.0f, -movementSpeed, 0.0f);
        playing = true;
        myAnimaton.SetTrigger("Active");
        myAnimaton.Play("Swimming", 0, 0.0f);
    }

    public void Backward()
    {
        Flip();
        transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0.0f, 0.0f);//player moves backwards
        playing = true;
        myAnimaton.Play("Swimming", 0, 0.0f);
        myAnimaton.SetBool("Bool", true);
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        playing = true;
        myAnimaton.Play("AlexanderJump", 0, 0.0f);
    }
}
