using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    //configs
    [SerializeField]
    public float movementSpeed = 300;

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
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;
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
    private bool cooldownActive = false;
    //sounds
    public AudioClip jump;
    public AudioClip slapshot;
    public AudioClip hurt;
    public AudioClip run;
    public AudioClip swordswing;
    private bool moving = false;
    private bool rDogButtonVisible = true;
    private Button rDogButton;

    //globals to move


    // Start is called before the first frame update
    void Start()
    {
        AlexHealth = 100;
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        capsuleColliderSize = cc.size;
        GameObject buttonObject = GameObject.Find("rdog");
        if (buttonObject != null)
        {
            rDogButton = buttonObject.GetComponent<Button>();
        }
        else
        {
            Debug.LogError("Button GameObject not found in the scene.");
        }

        //savedPlayerPosition = spawnPoint.transform.position;
    }
    
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
            Debug.Log("backwards");
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

        if (isAttackDown && !isBackwardDown)
        {
            // Check if enough time has passed since the last instantiation
            Debug.Log("Forward Shot");
            if (Time.time >= nextFireTime)
            {
                PlayerSoundEffects.PlayOneShot(slapshot);

                playing = true;
                myAnimaton.Play("AlexanderAttack", 0, 0);

                // Instantiate the "PuckObject" GameObject
                GameObject PuckObject = Instantiate(Puck, transform.position, transform.rotation);
                Rigidbody2D rb = PuckObject.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                                        float dir = isBackwardDown ? -1f : 1f;
                    rb.linearVelocity = new Vector2(dir * puckSpeed, 0.0f); // Move by facing, 0.0f); // Move right/forward
                }

                nextFireTime = Time.time + fireRate;
            }
        }




        if (isAttackDown && isBackwardDown)
        {
            Debug.Log("backwards Shot");

            // This block handles the attack going backward/left
            if (Time.time >= nextFireTime)
            {
                //... existing code for playing sound, animation, etc.
                PlayerSoundEffects.PlayOneShot(slapshot);

                playing = true;
                myAnimaton.Play("AlexanderAttack", 0, 0);
                // Instantiate the "PuckObject" GameObject for a backward attack
                GameObject PuckObject = Instantiate(Puck, transform.position, transform.rotation);
                Rigidbody2D rb = PuckObject.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                                        float dir = isBackwardDown ? -1f : 1f;
                    rb.linearVelocity = new Vector2(dir * puckSpeed, 0.0f); // Move by facing, 0.0f); // Move left/backward
                }

                nextFireTime = Time.time + fireRate;
            }
        }


        //ROBODOG NEW
        //If button is down and cooldown is not active, start the coroutine
        if (isRoboDogButtonDown && !cooldownActive)
        {
            StartCoroutine(RoboDogRoutine());
        }

     

    }
    //end of update TODO lets review this its way to big!




    IEnumerator RoboDogRoutine()
    {
        // Set robodog active and save the player position
        RoboDog.SetActive(true);
        Debug.Log("Active roboDog");
        savedPlayerPosition = this.transform.position;
        Debug.Log(savedPlayerPosition + "Players Position");
        RoboDog.transform.position = savedPlayerPosition;

        // Disable the rDogButton
        rDogButton.interactable = false;

        // Wait for 2 seconds before RoboDog starts moving
        yield return new WaitForSeconds(2);

        while (RoboDog.activeSelf)
        {
            Debug.Log("Killer dog?");
            RoboDog.transform.position += new Vector3(0.005f, 0.0f, 0.0f); // player move forward , forwardspeed can be change
                                                                                // If RoboDog is still active after 10 seconds, hide it
            if (Time.time >= 7f)
            {
                RoboDog.SetActive(false);
                break;
            }
            yield return null;
        }

        // Now start the cooldown
        cooldownActive = true;

        // Wait for 15 seconds
        yield return new WaitForSeconds(8);

        // After 15 seconds, reset the cooldown
        cooldownActive = false;

        // Enable the rDogButton
        rDogButton.interactable = true;
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
        GameObject newObject = Instantiate(Puck, transform.position, Puck.transform.rotation);
    }

    //IEnumerator FirePuck()
    //{

    //    yield return new WaitForSeconds(1);

    //}


        public void FarwardButton(bool state)
    {
        isForwardDown = state;
        if (state)
        {
            isFacingRight = true;
            if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null) spriteRenderer.flipX = false;
        }
    }


        public void BackwardButton(bool state)
    {
        isBackwardDown = state;
        if (state)
        {
            isFacingRight = false;
            if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null) spriteRenderer.flipX = true;
        }
    }

    public void flyFloat()
    {
        rb.gravityScale = 0.0f;
        rb.linearVelocity = Vector2.up * floatSpeed;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (rb.linearVelocity.y <= 0.0f)
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
