using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private float speed = 1f;
    private float horizontal;
    private  float jumpForce = 1100f;
    private bool isFacingRigth = true;
    public bool groundCheck = false;
    private bool isDead = false;
    public bool haveFlashLigth = false;
    public bool clickMouse = false;

    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] public Animator animator;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject flashLigth;
    [SerializeField] private GameObject flashRigth;
    void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    private void FixedUpdate()
    {
        WallingLogic();
        Flip();
        JumpLogic();
        WalkFlash();
        LigthOn();
    }
    public void Flip()
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
    private void WallingLogic()
    {
        if(isDead == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal == 1 || horizontal == -1)
            {
                animator.SetBool("IsWalk", true);
            }
            else
            {
                animator.SetBool("IsWalk", false);
            }


            rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
        }
       

    }
    private void WalkFlash()
    {
        if (Input.GetMouseButton(0) && haveFlashLigth == true)
        {
            animator.SetBool("IsWalkFlash", true);
            clickMouse = true;
        }
        else
        {
            animator.SetBool("IsWalkFlash", false);
            clickMouse = false;
        }
    }
    private void LigthOn()
    {
        if (clickMouse == true)
        {
            flashRigth.SetActive(true);
        }
        else
        {
            flashRigth.SetActive(false);
        }
    }
    private void PickUp(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Flashlight")
        {
            Destroy(flashLigth);
            haveFlashLigth = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundUpdate(collision, true);
        IsDead(collision, true);
        PickUp(collision);
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
    private void IsDead(Collision2D collision2D,bool value)
    {

        if(collision2D.gameObject.tag == "Trap")
        {
            if(value == true)
            {
                animator.SetBool("IsDead", true);
                Destroy(character, 2f);
                isDead = true;
            }
            
        }
        
    }
   
}
