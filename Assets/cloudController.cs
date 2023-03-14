using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudController : MonoBehaviour
{
    public float moveSpeed = 1f;

    private void Update()
    {
        moveSpeed = Random.Range(0, 1);
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

}
