using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float arrowSpeed = 4.0f;
    public int damage = 50;
    public PlayerCombat playerHealth;


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-arrowSpeed, 0f, 0f) * Time.deltaTime;


    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        { 
        
            
            
            Debug.Log("Ground hit");
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Player")
        {


            
            Debug.Log("Player hit");
            Destroy(gameObject);
            playerHealth.TakeDamage(damage);
        }








    }


}
