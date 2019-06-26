using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 0.28f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool Jump = false;
    bool Crouch = false;
    bool Magic = false;
    float moveLimiter = 0.5f;
    public bool m_FacingRight = true;
    Transform playerGraphics;
    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerGraphics = transform.FindChild("playergraphics");
    }

    // Update is called once per frame
    public void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove + verticalMove));

        if (Input.GetButtonDown("Magic"))
        {
            Magic = true;
            animator.SetBool("isMagic", true);

        }

        if (Input.GetButtonUp("Magic"))
        {
            Magic = false;
            animator.SetBool("isMagic", false);

        }

        if (Input.GetButtonDown("Jump"))
        {
            body.isKinematic = false;
            Jump = true;
            animator.SetBool("isJumping", true);
            body.AddForce(new Vector2(0f, controller.m_JumpForce));
        }
        if (Input.GetButtonDown("Crouch"))
        {
            Crouch = true;
            animator.SetBool("isCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            Crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool Crouch)
    {
        animator.SetBool("isCrouching", true);
    }

    void FixedUpdate()
    {
        // If the input is moving the player right and the player is facing left...
        if (horizontalMove + verticalMove > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove + verticalMove < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        if (horizontalMove != 0 && verticalMove != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontalMove *= moveLimiter;
            verticalMove *= moveLimiter;

            controller.Move(horizontalMove * Time.fixedDeltaTime, Crouch, Jump, Magic);
            controller.Move(verticalMove * Time.fixedDeltaTime, Crouch, Jump, Magic);
            body.isKinematic = true;
            
            Jump = false;
            Crouch = false;
            Magic = false;
        }

        body.velocity = new Vector2(horizontalMove * runSpeed, verticalMove * runSpeed);
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = playerGraphics.localScale;
        theScale.x *= -1;
        playerGraphics.localScale = theScale;
    }
}