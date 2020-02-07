using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunScript : MonoBehaviour
{
    public float jumpForce;
    private bool jump;
    private bool bunsTouching;
    private bool upperBunTouchingTopping;
    Rigidbody2D rbBunUp;
    public Rigidbody2D rbBunDown;


    void Start()
    {
        rbBunUp = GetComponent<Rigidbody2D>();
    }
    
    // Update is for input
    void Update()
    {
        if ((Input.GetButtonDown("Jump") || Input.touchCount > 0) & (bunsTouching || upperBunTouchingTopping))
            jump = true;
    }
  
    //FixedUpdate is for applying physics
    void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            // Add a vertical force (Jump)
            rbBunUp.AddForce(new Vector2(0.0f, jumpForce * 35f));
            rbBunDown.AddForce(new Vector2(0.0f, jumpForce * 25f));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "LowerBun")
        {
            bunsTouching = true;
        }
        if (collision.gameObject.name == "Topping")
        {
            upperBunTouchingTopping = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LowerBun")
        {
            bunsTouching = false;
        }
        if (collision.gameObject.name == "Topping")
        {
            upperBunTouchingTopping = false;
        }

    }
}
