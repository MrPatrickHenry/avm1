using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mechadonController : MonoBehaviour
{

    public int FatalDagme = 100;

    [SerializeField]
    private Animator myAnimaton;


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Physics2D.IgnoreLayerCollision(7, 7);

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Dead By MechaDon");
            HealthManager.lives -= 1;
        }


        if (HealthManager.AlexHealth <= 0)
        {
            // Get the current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Load the current scene again
            SceneManager.LoadScene(currentSceneIndex);
        }
    }


    }
