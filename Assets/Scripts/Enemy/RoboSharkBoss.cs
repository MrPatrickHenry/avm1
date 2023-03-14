using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoboSharkBoss : MonoBehaviour
{


    public int glooperDamage = 34;
    private int PlayerHelathUpdate;
    public float speed = 1f;
    [SerializeField]
    public Transform target;


    [SerializeField]
    private float movementSpeed = 2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "playerAlex")
        {
            Debug.Log("Damage Taken!");
            PlayerHelathUpdate = HealthManager.AlexHealth -= glooperDamage;
            Debug.Log(PlayerHelathUpdate);
            //PlayerController.DamageTaken()
            GameObject.Destroy(this);
        }

    }

    private void Update() { 
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

}
