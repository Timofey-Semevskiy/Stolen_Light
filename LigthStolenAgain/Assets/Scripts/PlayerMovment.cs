using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private float speed = 1f;
    private float horizontal;
    public  float jumpForce = 30f;
    private bool isFacingRigth = true;
    public bool groundCheck = false;
    
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private CircleCollider2D circleCollider;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
    }
    private void FixedUpdate()
    {
       
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
        Flip();
        JumpLogic();
    }
    private void Flip()
    {
        if(isFacingRigth && horizontal <0f || !isFacingRigth && horizontal > 0f)
        {
            
            Vector3 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
            isFacingRigth = !isFacingRigth;
        }
    }
    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (groundCheck == true)
            {
                rigidbody.AddForce(Vector2.up * jumpForce);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundUpdate(collision, true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGroundUpdate(collision, false);
    }
    private void IsGroundUpdate(Collision2D collision2D, bool value)
    {
        if(collision2D.gameObject.tag == "Ground")
        {
            groundCheck = value;
        }
    }
   
}
