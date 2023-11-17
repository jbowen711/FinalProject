using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject arrow;
    public float attackRate = 1.2f;
    float nextAttackTime = 0f;
    public GameObject player;
    int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
            

        }


    }
    public void Attack()
    {
        Debug.Log("Instantiate arrow");
        Instantiate(arrow, transform.position, Quaternion.identity);
    }

    public void DamageTaken(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        //hurt
        if (currentHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("Die");


    }


    public void Death()
    {
        Destroy(gameObject);
        Debug.Log("Enemy Died");
    }
}
