using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float move;
    [SerializeField] private float jump;
    [SerializeField] private bool isGrounded;

    public GameObject winPoint;

    float inputHorizontal;
    float inputVertical;
    //bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));


        if (inputHorizontal != 0)
        {
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        
        }
        

        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(2,2,1);
        }
        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 1);
        }


 



        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {

            rb.velocity = new Vector2(rb.velocity.x, jump);



        }
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);

        }
        if (collision.gameObject.tag == "Chest")
        {
            winPoint = GameObject.FindGameObjectWithTag("WinPoint");
            transform.position = winPoint.transform.position;
        }





    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }



        

    }
}
