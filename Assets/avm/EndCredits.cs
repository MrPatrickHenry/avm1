using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndCredits : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    [SerializeField] private Animator myAnimaton;

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            MoveTowards(target.position);
            //RotateTowards(target.position);
        }

    }

    private void Start()
    {
        myAnimaton.Play("running", 0, 0);

    }
    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
