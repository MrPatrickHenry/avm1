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
    public AudioClip PortalSwish;
    public AudioSource PlayerSoundEffects; // reference to the audio source component
    [SerializeField]
    bool finalLevelScene;

    private void Update()
    {
        transform.Rotate(XrotationsPerMinute, YrotationsPerMinute, ZrotationsPerMinute);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            PlayerSoundEffects.PlayOneShot(PortalSwish);

            if (finalLevelScene)
            {
                HighScore.UpdateHighScore();
            }
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
