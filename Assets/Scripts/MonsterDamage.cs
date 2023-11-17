using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public PlayerCombat playerHealth;

    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Player/Skeleton Collision");
            playerHealth.TakeDamage(damage);
        }
    }

}
