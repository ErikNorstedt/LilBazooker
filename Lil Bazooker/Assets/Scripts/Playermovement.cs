using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public Animator anim;

    public Rigidbody2D rb;
    public float speed;
    private bool isWalk;
    private bool hasStopped;
    private float moveInput;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float dampening;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Groundcheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Walking code
        if (Input.GetAxis("Horizontal") != 0 && isGrounded == true)
        {
            isWalk = true;
            hasStopped = false;
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        }
        else
        {
            isWalk = false;
        }
        if(isGrounded == false)
        {
            hasStopped = false;
        }
        
        if (isWalk == false && isGrounded== true && hasStopped == false)
        {
           
            Debug.Log("I Froze");
            rb.velocity *= Mathf.Pow(1f - dampening, Time.deltaTime * 10f);
            
            hasStopped = true;
        }
        if (isGrounded == true && isWalk == true)
        {
            anim.SetBool("IsWalking",true);
        }else
        {
            anim.SetBool("IsWalking", false);
        }

        //Jumping code
        if (Input.GetKeyDown(KeyCode.W) && isGrounded==true)
        {
            
            Debug.Log("Key pressed");
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, )
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
