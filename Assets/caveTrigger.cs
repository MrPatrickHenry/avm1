using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveTrigger : MonoBehaviour
{
    [SerializeField]
    public GameObject mask;
    public bool maskActive = false;
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
        Debug.Log(maskActive + " mask");
        if (collision.transform.tag == "Player")
        {
            //this is dumb!
            if (maskActive == false){
                mask.SetActive(true);
            }if (maskActive == true)
            {
                mask.SetActive(false);
            }

            Debug.Log("Queen Spider Start");
            gameObject.SetActive(false);
            mask.SetActive(maskActive);
        }

    }
}
