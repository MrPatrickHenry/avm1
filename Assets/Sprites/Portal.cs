    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    public float XrotationsPerMinute = 0f;
    [SerializeField]
    public float YrotationsPerMinute = 0f;
    [SerializeField]
    public float ZrotationsPerMinute = 0f;

    private void Update()
    {
        transform.Rotate(XrotationsPerMinute, YrotationsPerMinute, ZrotationsPerMinute);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
