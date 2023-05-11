using UnityEngine;
using UnityEngine.UI;

public class MobileInputController : MonoBehaviour
{
    [SerializeField]
    public CustomButton moveButton;
    [SerializeField]
    public CustomButton attackButton;
    [SerializeField]
    public GameObject Puck;
    [SerializeField]
    public CustomButton moveBackButton;

    private GameObject player;
    public float moveSpeed = 5.0f;
    public string runningAnimationName = "AlexanderRunningRemastered";
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

    [SerializeField]
    public CustomButton jumpButton;
    public float jumpForce = 5.0f;

    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;
    private Rigidbody2D playerRigidbody;

    //[SerializeField]
    //public Button pauseButton;

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

        //pauseButton.OnButtonPointerUp += TogglePause;

    }

    private void Update()
    {
        if (isMoving)
        {
            player.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (isMovingBackward)
        {
            player.transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
        }

    }

    private void OnMoveButtonPressed()
    {
        isMoving = true;
        playerAnimator.SetBool(runningAnimationName, isMoving);
        myAnimaton.Play("AlexanderRunningRemastered", 0, 0);
    }

    private void OnMoveButtonReleased()
    {
        isMoving = false;
        playerAnimator.SetBool(runningAnimationName, isMoving);
        myAnimaton.Play("PlayerIdle", 0, 0);
    }

    //Backwards
    private void OnMoveBackButtonPressed()
    {
        isMovingBackward = true;
        playerAnimator.SetBool(runningAnimationName, isMovingBackward);
        myAnimaton.Play("AlexanderRunningRemastered", 0, 0);
        //player.transform.localScale = new Vector3(-1f, 1f, 1f); // Flip the player
        transform.Rotate(0.0f, 180.0f, 0.0f);
        playerSpriteRenderer.flipX = true; // Flip the player
    }

    private void OnMoveBackButtonReleased()
    {
        isMovingBackward = false;
        playerAnimator.SetBool(runningAnimationName, isMovingBackward);
        myAnimaton.Play("PlayerIdle", 0, 0);
        player.transform.localScale = new Vector3(1f, 1f, 1f); // Reset the player's scale
        playerSpriteRenderer.flipX = false; // Flip the player
    }

    private void OnAttackButtonPressed()
    {
        if (Time.time >= nextFireTime)
        {
            PlayerSoundEffects.PlayOneShot(slapshot);

            playing = true;
            myAnimaton.Play("AlexanderAttack", 0, 0);

            // Instantiate the "PuckObject" GameObject
            GameObject PuckObject = Instantiate(Puck, transform.position, transform.rotation);
            // Check if the "isBackwardDown" variable is true
            if (isMovingBackward)
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

    private void OnAttackButtonReleased()
    {
        // Code to execute when the attack button is released
        if (isMoving)
        {
            myAnimaton.Play("AlexanderRunningRemastered", 0, 0);
        }
    }


    private void OnJumpButtonPressed()
    {
        //playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        myAnimaton.Play("AlexanderJump", 0, 0);

        playerRigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
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
