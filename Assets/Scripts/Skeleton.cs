using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    public GameObject player;
    int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
   



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    
        
        
    }


    void Update()
    {
        if (isChasing)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }


        }
        else
        {
            if (Vector2.Distance(transform.position, player.transform.position) < chaseDistance) {
                isChasing = true;
            }
        }
        

    }

    public void Attack()
    {
        


    }

    public void Hit()
    {

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
