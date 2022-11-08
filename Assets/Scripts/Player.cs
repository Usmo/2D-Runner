using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public GameObject startPosition;

    public DeathScreen deathScreen;

    public float jumpForce = 400f;
    public float runSpeed = 200f;
    public int health = 1;

    public bool isAlive = true;

    float horizontalMove = 0f;
    bool jump = false;
    bool lookingRight = true;


    void Start()
    {
        if (startPosition != null)
        {
            transform.position = startPosition.transform.position;
        }

    }
    void Update()
    {
        // Check inputs and update variables
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (animator != null)
        {
            animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        }
        
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

        // Multiply the player's x local scale by -1 to flip it.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // onLanding and onFalling are events for animations
    public void onLanding()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
    }
    public void onFalling()
    {
        animator.SetBool("isFalling", true);
    }

    // TODO: Player death animation
    // at player death -> animator.SetBool("isAlive", false);
    // and at reset level -> animator.SetBool("isAlive", true);

    public void takeDamage()
    {
        health--;
        if (health <= 0)
        {
            isAlive = false;
            if (animator != null) { 
                animator.SetBool("isAlive", false); 
            }

            if (deathScreen != null)
            {
                deathScreen.ShowDeathScreen();
            }
        }
    }
    
    public void resetLevel()
        // Reset all player related variables
    {
        // After coins have been added to game, here should be a function to reactivate all collected coins

        Time.timeScale = 1f;
        if (startPosition != null ) transform.position = startPosition.transform.position; // null check so test can be run without it
        health = 1;
        isAlive = true;

        if (animator != null) animator.SetBool("isAlive", true);

    }

}
