using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BunScript : MonoBehaviour
{
    //Bool
    bool jump;
    bool bunsTouching;
    bool upperBunTouchingTopping;
    //Float
    public float jumpForce;
    //Rigidbody
    Rigidbody2D rbBunUp;
    public Rigidbody2D rbBunDown;

    void Start()
    {
        rbBunUp = GetComponent<Rigidbody2D>();
        
        //Listen to gameOver event
        //Events.gameOver.AddListener(GameOver);
    }
    
    // Update is for input
    void Update()
    {
        if ((Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) & (bunsTouching || upperBunTouchingTopping) & !PauseMenuScript.isPaused)
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
            rbBunDown.AddForce(new Vector2(0.0f, jumpForce * 20f));
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name ==  "NewTopping") {
            Events.instantiateTopping.Invoke();
            Events.increaseScore.Invoke();
        }
        else{
            if(other.gameObject.name !=  "LowerBun") {
                Events.gameOver.Invoke();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.name == "LowerBun")
        {
            bunsTouching = true;
        }
        if(other.gameObject.name == "Topping")
        {
            upperBunTouchingTopping = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.name == "LowerBun")
        {
            bunsTouching = false;
        }
        if(other.gameObject.name == "Topping")
        {
            upperBunTouchingTopping = false;
        }
    }

}
