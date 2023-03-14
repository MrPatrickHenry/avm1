using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{

    [SerializeField]
    private Animator myAnimaton;
    public GameObject Puck;
    public float puckSpeed = 30;
    public bool playing = false;
    [SerializeField]
    public GameObject RoboDogObj;
    public int AttackSpeed;

    //PUCK
    public void fire()
    {
        playing = true;
        myAnimaton.Play("AlexanderAttack", 0, 0.0f);
        Debug.Log("animation Played");
        if (!Puck.activeSelf)
        {
            Debug.Log("Puck Active");

            Puck.SetActive(true);
            PlayerManager.savedPlayerPosition = this.transform.position;
            Debug.Log("dropped puck");
            Puck.transform.position = PlayerManager.savedPlayerPosition;
            Debug.Log("dropped firing puck");

            Puck.transform.position += new Vector3(puckSpeed, 0.0f, 0.0f);
            Debug.Log("fired puck");


        }
        if (Puck.activeSelf)
        {
            //TODO fix backswing
            //if (isBackwardDown)
            //{
            //    Debug.Log("backhand shot?");
            //    Puck.transform.position += new Vector3(-puckSpeed, 0.0f, 0.0f);
            //}
            //GetComponent<AudioSource>().clip = _swingAttack;
            //_audioSource.Play();

            Puck.transform.position += new Vector3(puckSpeed, 0.0f, 0.0f);
            Puck.SetActive(false);

        }
    }

    //ROBODOG ATTACK CODE!
    public void RoboDog() {
            if (!RoboDogObj.activeSelf)
            {
                Debug.Log("Get Him BOY!");
                RoboDogObj.SetActive(true);
                PlayerManager.savedPlayerPosition = this.transform.position;
                RoboDogObj.transform.position = PlayerManager.savedPlayerPosition;
            }
            if (RoboDogObj.activeSelf)
            {
                Debug.Log("Killer dog?");
            RoboDogObj.transform.position += new Vector3(AttackSpeed, 0.0f, 0.0f);// player move forward , forwardspeed can be change
        }
    }
    }
