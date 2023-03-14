using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public int glooperDamage = 8;
    [SerializeField]
    public AudioSource _audioSourceGlopper;

    [SerializeField]
    public AudioClip _hurt;

    [SerializeField]
    public AudioClip _glooperDead;
    public Transform target;
    public float speed = 1f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            MoveTowards(target.position);
            //RotateTowards(target.position);
        }
        if (Time.timeScale == 0) return;
    }

    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void RotateTowards(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //var offset = 90f;
        //transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

}
