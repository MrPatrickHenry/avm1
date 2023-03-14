using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class transitionScne : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("nextSceneTransiton", 6f);
    }

    void nextSceneTransiton()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
