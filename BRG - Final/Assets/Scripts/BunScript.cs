using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunScript : MonoBehaviour
{
    //Bool
    private bool jump;
    private bool bunsTouching;
    private bool upperBunTouchingTopping;
    //Int
    private int score;
    //Float
    public float jumpForce;
    private float InstantiateToppingY;
    //Rigidbody
    Rigidbody2D rbBunUp;
    public Rigidbody2D rbBunDown;
    //GameObject
    private GameObject NextTopping;
    public GameObject NewToppingPrefab;
    //UI
    public Text scoreText;
    //Others
    public Sprite[] ToppingSprites;

    void Start()
    {
        rbBunUp = GetComponent<Rigidbody2D>();
        InstantiateToppingY = GameObject.Find("NewTopping").transform.position.y;
        //Listen to gameOver event
        Events.gameOver.AddListener(GameOver);
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
            rbBunDown.AddForce(new Vector2(0.0f, jumpForce * 20f));
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name ==  "NewTopping") {
            InstantiateTopping();
            IncreaseScore();
        }
        else{
            if(other.gameObject.name !=  "LowerBun") {
                GameOver();
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

    private void IncreaseScore(){
        score++;
        scoreText.text = score.ToString(); 
    }

    private void InstantiateTopping()
    {
        float x = transform.position.x + Random.Range(10, 16);
        NextTopping = Instantiate(NewToppingPrefab, new Vector2(x, InstantiateToppingY), Quaternion.identity) as GameObject;
        NextTopping.name = "NewTopping";
        InstantiateToppingY += NextTopping.GetComponent<BoxCollider2D>().size.y;
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

    public void GameOver(){
        Debug.Log("Perdiste");
    }
}
