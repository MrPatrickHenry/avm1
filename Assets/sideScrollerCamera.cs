using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideScrollerCamera : MonoBehaviour
{


    public float cameraSpeed = 5f;
    public float levelDuration = 90; // level duration in seconds
    private float timer = 0f;

    private void Start()
    {
        transform.position = new Vector3(-100, -18, -10);
    }

    private void Update()
    {
        // increase timer
        timer += Time.deltaTime;

        // calculate camera position
        float cameraX = Mathf.Lerp(0f, 270, timer / levelDuration);

        // set camera position
        transform.position = new Vector3(cameraX, transform.position.y, transform.position.z);
    }
}
