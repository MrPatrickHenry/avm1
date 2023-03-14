using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gloopers: MonoBehaviour
{
    //public int glooperDamage = 5;
    //private int PlayerHelathUpdate;
    //public Transform target;
    //public float speed = 1f;
    //[SerializeField] private Animator myAnimaton;
    ////[SerializeField] private string explode = "DeadGlooper";
    //[SerializeField] private float timeDelay;
    //[SerializeField]
    //public AudioSource _audioSourceGlopper;

    //[SerializeField]
    //public AudioClip _hurt;

    //[SerializeField]
    //public AudioClip _glooperDead;

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Physics2D.IgnoreLayerCollision(7, 7, true);

    //    if (collision.gameObject.tag == "Player")
    //    {

    //        CharacterController.DamageTaken();
    //        Debug.Log("Damage Taken!");
    //        PlayerHelathUpdate = CharacterController.AlexHealth -= glooperDamage;
    //        Debug.Log(PlayerHelathUpdate);
    //        CharacterController.damgeUpdate = PlayerHelathUpdate.ToString();
    //        //PlayerController.DamageTaken()
    //    }

    //    if (collision.gameObject.tag == "weaponFired")
    //    {

    //        //_audioSourceGlopper.clip = _glooperDead;
    //        //_audioSourceGlopper.Play();

    //    }
    //}



    //private void Update()
    //{
    //    if (Vector3.Distance(transform.position, target.position) > 1f)
    //    {
    //        MoveTowards(target.position);
    //        //RotateTowards(target.position);
    //    }
    //}

    //private void MoveTowards(Vector2 target)
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    //}

    //private void RotateTowards(Vector2 target)
    //{
    //    Vector2 direction = (target - (Vector2)transform.position).normalized;
    //    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    //var offset = 90f;
    //    //transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    //}



}
