using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mechadonController : MonoBehaviour
{


    [SerializeField]
    private Animator myAnimaton;


    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Physics2D.IgnoreLayerCollision(7, 7, true);

        if (collision.gameObject.tag == "player")
        {
            Debug.Log("dead");
            StartCoroutine(GetHurt());
            HealthManager.lives -= 1;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    IEnumerator GetHurt()
    {
        myAnimaton.Play("AlexanderDamaged", 0, 0.0f);
        yield return new WaitForSeconds(2);
    }
}
