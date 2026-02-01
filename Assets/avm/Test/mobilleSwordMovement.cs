using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobilleSwordMovement : MonoBehaviour
{
    [SerializeField]
    public CustomButton moveButton;
    [SerializeField]
    public CustomButton attackButton;
    [SerializeField]
    public GameObject FwdAttackSwing;
    [SerializeField]
    public GameObject FwdBackSwing;
    [SerializeField]
    public CustomButton moveBackButton;

    private GameObject player;
    public float moveSpeed = 5.0f;
    public string runningAnimationName = "SwordRun";
    [SerializeField]
    private Animator myAnimaton;
    private bool isMoving = false;
    private bool isMovingBackward = false;
    private int facingDirection = 1;
    private float nextFireTime;
    public float fireRate; // The number of seconds between each instantiation
    public AudioSource PlayerSoundEffects; // reference to the audio source component
    public AudioClip slapshot;
    private bool playing = false;
    public float puckSpeed;
    private int jumpsMade;
    private const int maxJumps = 2;

    [SerializeField]
    public CustomButton jumpButton;
    public float jumpForce = 5.0f;

    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;
    private Rigidbody2D playerRigidbody;
    private int playerIdleHash;

    //[SerializeField]
    //public Button pauseButton;



    public LayerMask groundLayer; // To specify which layer is the ground layer
    public Transform groundCheck; // To specify where the ground check will take place
    private bool isGrounded; // To store whether the player is on the ground or not
    public float checkRadius; // To specify the radius of the ground check




    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        moveButton.OnButtonPointerDown += OnMoveButtonPressed;
        moveButton.OnButtonPointerUp += OnMoveButtonReleased;

        moveBackButton.OnButtonPointerDown += OnMoveBackButtonPressed;
        moveBackButton.OnButtonPointerUp += OnMoveBackButtonReleased;

        attackButton.OnButtonPointerDown += OnAttackButtonPressed;
        attackButton.OnButtonPointerUp += OnAttackButtonReleased;

        jumpButton.OnButtonPointerDown += OnJumpButtonPressed;
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerIdleHash = Animator.StringToHash("PlayerIdle");

        //pauseButton.OnButtonPointerUp += TogglePause;

    }

    private void Update()
    {
        if (isMoving)
        {
            player.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            // Check if the current animation is "PlayerIdle"
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash == playerIdleHash)
            {
                // Change the animation to "AlexanderRunningRemastered"
                myAnimaton.Play("SwordRun", 0, 0);
            }
        }

        if (isMovingBackward)
        {
            player.transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
            // Check if the current animation is "PlayerIdle"
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash == playerIdleHash)
            {
                // Change the animation to "AlexanderRunningRemastered"
                myAnimaton.Play("SwordRun", 0, 0);
            }
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

    }

    private void OnMoveButtonPressed()
    {
        isMoving = true;
        playerAnimator.SetBool(runningAnimationName, isMoving);
        myAnimaton.Play("SwordRun", 0, 0);
    }

    private void OnMoveButtonReleased()
    {
        isMoving = false;
        playerAnimator.SetBool(runningAnimationName, isMoving);
        myAnimaton.Play("IdolSword", 0, 0);
    }

    //Backwards
    private void OnMoveBackButtonPressed()
    {
        isMovingBackward = true;
        playerAnimator.SetBool(runningAnimationName, isMovingBackward);
        myAnimaton.Play("SwordRun", 0, 0);
        //player.transform.localScale = new Vector3(-1f, 1f, 1f); // Flip the player
        transform.Rotate(0.0f, 180.0f, 0.0f);
        playerSpriteRenderer.flipX = true; // Flip the player
    }

    private void OnMoveBackButtonReleased()
    {
        isMovingBackward = false;
        playerAnimator.SetBool(runningAnimationName, isMovingBackward);
        myAnimaton.Play("IdolSword", 0, 0);
        player.transform.localScale = new Vector3(1f, 1f, 1f); // Reset the player's scale
        playerSpriteRenderer.flipX = false; // Flip the player
    }

    private IEnumerator DeactivateColliderAfterDelay(GameObject gameObject, float delay)
{
    yield return new WaitForSeconds(delay);
    gameObject.SetActive(false);
}

private IEnumerator ActivateColliderAfterDelay(GameObject gameObject, float delay)
{
    yield return new WaitForSeconds(delay);
    gameObject.SetActive(true);
}

private void OnAttackButtonPressed()
{
    Debug.Log("Attack button pressed");
    if (Time.time >= nextFireTime)
    {
        PlayerSoundEffects.PlayOneShot(slapshot);   

        playing = true;
        StartCoroutine(ActivateColliderAfterDelay(FwdAttackSwing, 0.5f)); // set a delay of 0.5s

        myAnimaton.Play("swordAttack", 0, 0);

        // Code to execute when the attack button is pressed
        nextFireTime = Time.time + fireRate;

        StartCoroutine(DeactivateColliderAfterDelay(FwdAttackSwing, fireRate));
    }
    Debug.Log("end of attack button pressed");
}


private void OnAttackButtonReleased()
{
    // Code to execute when the attack button is released
    if (isMoving)
    {
        myAnimaton.Play("SwordRun", 0, 0);
    }
}


    private void OnJumpButtonPressed()
    {
        //if (isGrounded)
        //{
        //    isGrounded = false;
            myAnimaton.Play("SwordJump", 0, 0);
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            StartCoroutine(ActivateColliderAfterDelay(FwdAttackSwing, 0.5f)); // Collider activates 0.5s after jump is pressed.

        //isGrounded = true;
        //}
    }

    private void TogglePause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
