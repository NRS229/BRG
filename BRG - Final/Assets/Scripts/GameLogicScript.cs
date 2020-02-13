using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    //Int
    private int score;
    //Float
    private float InstantiateToppingY;
    //GameObject
    private GameObject NextTopping;
    public GameObject NewToppingPrefab;
    //UI
    public Text scoreText;
    //Others
    public Sprite[] ToppingSprites;


    public static GameLogicScript current;
    private void Awake(){
        current = this;
    }

    void Start()
    {
        InstantiateToppingY = GameObject.Find("NewTopping").transform.position.y;
        //Listen to events
        Events.gameOver.AddListener(GameOver);
        Events.instantiateTopping.AddListener(InstantiateTopping);
        Events.increaseScore.AddListener(IncreaseScore);
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
