using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMask : MonoBehaviour
{
    public string maskName;
    private bool powerMaskActive = false;
    private float powerMaskDuration = 10.0f; // duration of power mask in seconds
    private float powerMaskTimer = 0.0f; // timer for power mask
    public GameObject equippedPowerMask;
    public GameObject Player;


    //forcefield
    public float forceFieldRadius = 5.0f;
    public float forceFieldPower = 10.0f;
    public LayerMask enemyLayer;

    //invicible
    float invincibilityDuration = 10.0f;
    float invincibilityTimer = 0.0f;

    private void Start()
    {
        Debug.Log("mask" + equippedPowerMask);
        equippedPowerMask.SetActive(false);
    }

    void Update()
    {
        // check if power mask is active
        if (powerMaskActive)
        {
            // update timer
            powerMaskTimer += Time.deltaTime;

            // check if power mask duration has expired
            if (powerMaskTimer >= powerMaskDuration)
            {
                // power mask duration has expired, set power mask to inactive and reset timer
                powerMaskActive = false;
                powerMaskTimer = 0.0f;
                equippedPowerMask.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpriteRenderer spriteRenderer = equippedPowerMask.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRendererPlayer = Player.GetComponent<SpriteRenderer>();
            Debug.Log("mask collected");

            equippedPowerMask.SetActive(true);
            Debug.Log(equippedPowerMask);

            switch (maskName)
            {
                case "Red":
                    // Apply laser beam power
                    spriteRenderer.color = Color.red;
                    Debug.Log("LaserBEAM!");
                    break;
                case "Orange":
                    spriteRenderer.color = Color.black;
                    Debug.Log("ForeField!");
                    ActivateForceField();
                    break;
                case "Yellow":
                    // Apply health recover power (time based)
                    spriteRenderer.color = Color.yellow;

                    StartCoroutine(RecoverHealth());

                    Debug.Log("health!");
                    break;
                case "Green":
                    // Apply nature attack power
                    spriteRenderer.color = Color.green;
                    Debug.Log("nature attack!");
                    break;
                case "Blue":
                    // Apply water power
                    spriteRenderer.color = Color.blue;
                    Debug.Log("water!");
                    break;
                case "Pink":
                    // Apply flying power
                    spriteRenderer.color = Color.magenta;
                    Debug.Log("fly/float!");
                    break;
                case "White":
                    // Apply invisibility power
                    spriteRenderer.color = Color.white;

                    spriteRendererPlayer.color = new Color(1f, 1f, 1f, 0.1f);

                    Debug.Log("invisabel man!");
                    break;
                case "Black":
                    // Apply super strength power
                    spriteRenderer.color = Color.black;
                    Player.transform.localScale *= 1.5f;
                    //Puck.damage *= 2;
                    Debug.Log("strenght!");
                    break;
                case "Spectrum":
                    // Apply invincibility power
                    // Apply invincibility power
                    Color[] colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow, Color.magenta };

                    StartCoroutine(ChangeColorRoutine(colors, spriteRenderer));
                    Debug.Log("invincible!");
                    break;
                default:
                    // Handle the case where the powerMaskName does not match any of the defined cases
                    break;
            }

            // Destroy the power mask game object after the player has collided with it
            Destroy(gameObject);
        }


    }

    private IEnumerator ChangeColorRoutine(Color[] colors, SpriteRenderer spriteRenderer, float timeBetweenColors = 1f)
    {
        int index = 0;
        while (equippedPowerMask.active)
        {
            // Set the sprite color to the selected color
            spriteRenderer.color = colors[index];
            index = (index + 1) % colors.Length;
            yield return new WaitForSeconds(timeBetweenColors);
        }
    }


    IEnumerator RecoverHealth()
    {
        float duration = 10.0f;
        float timer = 0.0f;

        // Update health every second for 10 seconds
        while (timer < duration)
        {
            yield return new WaitForSeconds(1.0f);
            HealthManager.AlexHealth += 1;
            Debug.Log(HealthManager.AlexHealth);
            timer += 1.0f;
        }
    }



    public void ActivateForceField()
    {
        //OnDrawGizmosSelected();
        // Get all enemies within the force field radius
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, forceFieldRadius, enemyLayer);

        // Apply force to each enemy
        foreach (Collider2D enemy in enemies)
        {
            Vector2 direction = enemy.transform.position - transform.position;
            direction = direction.normalized;
            enemy.GetComponent<Rigidbody2D>().AddForce(direction * forceFieldPower, ForceMode2D.Impulse);
        }
    }

    // Debug draw the force field radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, forceFieldRadius);
    }



}
