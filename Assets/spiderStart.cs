using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class spiderStart : MonoBehaviour
{
    [SerializeField]
    public float ortho;
    [SerializeField]
    public string BossName;
    [SerializeField]
    public GameObject BossTitle;
    public GameObject BgImageScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //BossTitle = BossName;
            BossTitle.SetActive(true);
            Invoke("HideBossTitle", 1f);
            Debug.Log("co routine ended.");
            ZoomOut();
            gameObject.SetActive(false);
            BgImageScene.transform.localScale = new Vector3(20f, 20f, 20f);


        }

    }

    void HideBossTitle()
    {
       
        BossTitle.SetActive(false);
    }

    public void ZoomOut()
    {
        //vcam.m_Lens.OrthographicSize = 20;
    }


}
