using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float jumpForce = 400f;

    public float runSpeed = 200f;

    public int health = 1;

    float horizontalMove = 0f;
    bool jump = false;
    bool lookingRight = true;


    void Update()
    {
        // Check inputs and update variables
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if(lookingRight && horizontalMove < 0)
        {
            Flip();
        }
        else if(!lookingRight && horizontalMove > 0)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        if (jump)
        {
            animator.SetBool("isJumping", true);
        }
        
        
        jump = false;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        lookingRight = !lookingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

}
