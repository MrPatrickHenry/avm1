using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    //configs
    [SerializeField]
    public float movementSpeed =300;
    
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private float jumpForce = 15;
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
    [SerializeField]
    TextMeshProUGUI healthRemaining;
    [SerializeField]
    GameObject GameOVER;
    [SerializeField]
    TextMeshProUGUI livesRemaining;
    public static int Score;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private Animator myAnimaton;
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
    public float timeRemaining = 10;
    private Vector2 savedPlayerPosition;
    [SerializeField]
    public GameObject Puck;
    bool isAttackDown = false;
    private int PlayerHelathUpdate;
    public static int AlexHealth = 100;
    public static string damgeUpdate;
    public int glooperDamage = 5;
    public GameObject spawnPoint;
    public static int lives = 4;
    private Vector2 slopeNormalPerp;
    private bool playing = false;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    [SerializeField]
    public GameObject RoboDog;
    private bool isMoving;
    //configs for controlls
    public float forwardSpeed;
    public float backwardSpeed;
    public float AttackSpeed;
    public float puckSpeed;
    bool isForwardDown = false;
   public static bool isBackwardDown = false;
    bool isRoboDogButtonDown = false;
    public int pucksPS = 1;
    public float fireRate; // The number of seconds between each instantiation
    private float nextFireTime;
    private float floatSpeed = 5.0f;
    public AudioSource PlayerSoundEffects; // reference to the audio source component
 //sounds
    public AudioClip jump;
    public AudioClip slapshot;
    public AudioClip hurt;
    public AudioClip run;
    public AudioClip swordswing;
    private bool moving = false;
    //globals to move


    // Start is called before the first frame update
    void Start()
    {
        AlexHealth = 100;
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        capsuleColliderSize = cc.size;

        //savedPlayerPosition = spawnPoint.transform.position;
    }
    //private void FixedUpdate()
    //{
    //    if (isForwardDown)
    //    {
    //        //transform.position += new Vector3(movementSpeed * Time.deltaTime, 0.0f, 0.0f);
    //        StartCoroutine(PlayAnimationLoop());
    //    }

    //    if (isBackwardDown)
    //    {
    //        transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0.0f, 0.0f);
    //        playing = true;
    //        myAnimaton.Play("AlexanderRunningRemastered", 0, 0);
    //        myAnimaton.SetBool("Bool", true);
    //    }
    //}

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
                myAnimaton.Play("AlexanderRunningRemastered", 0, 0);
                //myAnimaton.SetBool("Bool", true);
            }
        }
        else
        {
            // Stop playing the animation when the player stops moving
            moving = false;
             //myAnimaton.SetBool("Bool", false);
        }


        if (isForwardDown)
        {

            //rb.AddForce(new Vector2(2 * movementSpeed * Time.deltaTime, 0));

            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0.0f, 0.0f);//player moves backwards
            if (!moving)
            {
                moving = true;
                myAnimaton.Play("AlexanderRunningRemastered", 0, 0);
                //myAnimaton.SetBool("Bool", true);
            }
            else
            {
                // Stop playing the animation when the player stops moving
                moving = false;
                //myAnimaton.SetBool("Bool", false);
            }

        }

        //while (isBackwardDown)
        //{
        //    StartCoroutine(PlayAnimationLoop());

        //}

        if (isBackwardDown)
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0.0f, 0.0f);//player moves backwards
            playing = true;
            myAnimaton.Play("AlexanderRunningRemastered", 0, 0);
            myAnimaton.SetBool("Bool", true);


        }

        if (isJumpDown)
        {
            if (!isJumping && !groundCheck)
            {
                Jump();
                isJumping = true;

            }
        }


            //Attack
            // Check if the "isAttackDown" variable is true

            if (isAttackDown)
            {
                    // Check if enough time has passed since the last instantiation

                    if (Time.time >= nextFireTime)
                    {
                    PlayerSoundEffects.PlayOneShot(slapshot);

                playing = true;
                        myAnimaton.Play("AlexanderAttack", 0, 0);

                        // Instantiate the "PuckObject" GameObject
                        GameObject PuckObject = Instantiate(Puck, transform.position, transform.rotation);
                        // Check if the "isBackwardDown" variable is true
                        if (isBackwardDown)
                        {
                            Debug.Log("backhand shot?");
                            // Adjust the position of the "PuckObject" GameObject
                            PuckObject.transform.position += new Vector3(-puckSpeed * Time.deltaTime, 0.0f, 0.0f);
                        }
                        else
                        {
                            // Adjust the position of the "PuckObject" GameObject
                            PuckObject.transform.position += new Vector3(puckSpeed * Time.deltaTime, 0.0f, 0.0f);
                        }
                // Update the time of the next allowed instantiation
                //attacButton.SetActive(false);

                nextFireTime = Time.time + fireRate;
                    }

                }

                //ROBODOG
                if (isRoboDogButtonDown) {

            //RoboDogHide();
            if (!RoboDog.activeSelf)
            {
                Debug.Log("Get Him BOY!");
                RoboDog.SetActive(true);
                Debug.Log("Active roboDog");
                savedPlayerPosition = this.transform.position;
                Debug.Log(savedPlayerPosition + "Players Position");
                RoboDog.transform.position = savedPlayerPosition;
            }
            if (RoboDog.activeSelf)
            {
                Debug.Log("Killer dog?");
                RoboDog.transform.position += new Vector3(AttackSpeed, 0.0f, 0.0f);// player move forward , forwardspeed can be change
            }
        }
    }

    IEnumerator PlayAnimationLoop()
    {
        // Play the animation on a loop while isForwardDown is true
        myAnimaton.Play("AlexanderRunningRemastered", 0, 0);
        //myAnimaton.SetBool("Bool", true);

        // Wait for the next frame
        yield return null;

        // Check if isForwardDown is still true
        if (isForwardDown)
        {
            // Start the coroutine again
            StartCoroutine(PlayAnimationLoop());
        }
    }

    void SawnOject()
    {
        GameObject newObject = Instantiate(Puck,transform.position,Puck.transform.rotation);
    }

    //IEnumerator FirePuck()
    //{

    //    yield return new WaitForSeconds(1);

    //}


    public void FarwardButton(bool state)
    {
        isForwardDown = state;
    }


    public void BackwardButton(bool state)
    {
        isBackwardDown = state;
        Flip();

    }

    public void flyFloat()
    {
        rb.gravityScale = 0.0f;
        rb.velocity = Vector2.up * floatSpeed;
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

    public void RoboAttackButton(bool state)
    {
        isRoboDogButtonDown = state;
    }


    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void attack(bool state)
    {
        isAttackDown = state;
    }

    void feedDog()
    {
        savedPlayerPosition = this.transform.position;
        Debug.Log(savedPlayerPosition + "Players Position");
        Puck.transform.position = savedPlayerPosition;
        Puck.SetActive(false);
    }

    //Jump
    public void Jump()
    {
        PlayerSoundEffects.PlayOneShot(jump);

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }



}
