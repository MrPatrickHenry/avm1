using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam : MonoBehaviour
{

    public Material material;
    WebCamTexture webCamTexture;



    void Start()
    {
        webCamTexture = new WebCamTexture();
        material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }
}
