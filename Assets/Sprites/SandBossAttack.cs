using UnityEngine;

public class SandBossAttack : MonoBehaviour
{

    public int glooperDamage = 10;
    private int PlayerHelathUpdate;
    public GameObject bossAttackProjectile;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerAlex")
        {
            Debug.Log("Damage Taken!");
            PlayerHelathUpdate = HealthManager.AlexHealth -= glooperDamage;
            Debug.Log(PlayerHelathUpdate);
        }

    }
}
