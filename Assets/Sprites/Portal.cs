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
    public GameObject HighScores;

    [SerializeField]
    public GameObject HighScoreUI;


    private void Update()
    {
        transform.Rotate(XrotationsPerMinute, YrotationsPerMinute, ZrotationsPerMinute);
    }
    private void LoadNextScene()
    {
        new WaitForSeconds(3);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }


    IEnumerator ShowHighScoreAndLoadNextScene()
    {
        Debug.Log("calculating score");
        HighScoreUI.SetActive(true);
        HighScore.UpdateHighScore();
        yield return new WaitForSeconds(5);
        LoadNextScene();
    }



    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            PlayerSoundEffects.PlayOneShot(PortalSwish);

            if (finalLevelScene)
            {
                StartCoroutine(ShowHighScoreAndLoadNextScene());
            }
            else
            {
                Debug.Log("not end scene");
                LoadNextScene();
            }

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
