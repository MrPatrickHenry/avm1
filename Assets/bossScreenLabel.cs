using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScreenLabel : MonoBehaviour
{


    [SerializeField]
    public GameObject BossTitle;

    // Start is called before the first frame update
    void Start()
    {
        //BossTitle = BossName;
        BossTitle.SetActive(true);
        Invoke("HideBossTitle", 1f);
        Debug.Log("co routine ended.");
        //gameObject.SetActive(false);
    }



void HideBossTitle()
{

    BossTitle.SetActive(false);
}

}
