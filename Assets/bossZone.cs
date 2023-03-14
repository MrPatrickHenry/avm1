using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossZone : MonoBehaviour
{

    public GameObject BossObject;
    public GameObject Boss;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "YetiBalls")
        {
            BossObject.SetActive(false);
        }
    }

}
