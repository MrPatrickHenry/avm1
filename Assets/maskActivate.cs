using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskActivate : MonoBehaviour
{
    public GameObject Mask;
    public GameObject activate;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "playerAlex")
        {
            Mask.SetActive(true);
            Destroy(this);
            activate.SetActive(false);
        }
    }

}
