using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunScript : MonoBehaviour
{
    public float jumpForce;
    private bool jump;
    private bool bunsTouching;
    private bool upperBunTouchingTopping;
    Rigidbody2D rbBunUp;
    public Rigidbody2D rbBunDown;
    private GameObject NextTopping;
    public GameObject NewToppingPrefab;
    public Sprite[] ToppingSprites;
    private int score;
    public Text scoreText;


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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "NewTopping")
        {
            InstantiateTopping();
            IncreaseScore();
        }
    }

    private void IncreaseScore(){
        score++;
        scoreText.text = score.ToString(); 
    }

    private void InstantiateTopping()
    {
        float x = transform.position.x + Random.Range(10, 16);
        float y = transform.position.y - 0.3f;

        NextTopping = Instantiate(NewToppingPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
        NextTopping.name = "NewTopping";
        RandomNextToppingSprite();
    }

    public void RandomNextToppingSprite()
    {
        int nextToppingSpriteRandom = Random.Range(1, 5);
        switch (nextToppingSpriteRandom)
        {
            case 1:
                NextTopping.GetComponent<SpriteRenderer>().sprite = ToppingSprites[0];
                break;

            case 2:
                NextTopping.GetComponent<SpriteRenderer>().sprite = ToppingSprites[1];
                break;

            case 3:
                NextTopping.GetComponent<SpriteRenderer>().sprite = ToppingSprites[2];
                break;

            case 4:
                NextTopping.GetComponent<SpriteRenderer>().sprite = ToppingSprites[3];
                break;
        }
    }
}
