using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimming : MonoBehaviour
{


    [SerializeField]
    public Animator myAnimaton;
    private string playerAnimation;


    // Start is called before the first frame update
    void Start()
    {
        myAnimaton.Play("Swimming", 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
