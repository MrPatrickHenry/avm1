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
            // Get the GameObject's name and set it to "Background1"
            GameObject background = gameObject;
            background.name = "Background1";
            background.SetActive(false);

            // Toggle the mask active state
            maskActive = !maskActive;
            mask.SetActive(maskActive);

            Debug.Log("Queen Spider Start");
            gameObject.SetActive(false);
        }
    }
}
