using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform Sword;
    public float attackRange = .0f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deathSpawn;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }

        if (currentHealth < 0)
        {
            animator.SetTrigger("Die");
        }


        

    }


    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Sword.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy has been hit");
            enemy.GetComponent<Skeleton>().DamageTaken(attackDamage);
            enemy.GetComponent<Archer>().DamageTaken(attackDamage);
        }
        
    }

    private void OnDrawGizmos()
    {
        if (Sword == null)
            return;
        Gizmos.DrawWireSphere(Sword.position, attackRange);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Damage Taken");
        animator.SetTrigger("PlayerHurt");

    }

    public void Die()
    {
        deathSpawn = GameObject.FindGameObjectWithTag("DeathSpawn");
        transform.position = deathSpawn.transform.position;
        //Destroy(gameObject);
        
    }



}
