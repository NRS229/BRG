using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicScript : MonoBehaviour
{
    //Bool
    public static bool isPlaying = false;
    //Float
    private float InstantiateToppingY;
    //GameObject
    private GameObject NextTopping;
    public GameObject NewToppingPrefab;
    //Others
    public Sprite[] ToppingSprites;

    public static GameLogicScript current;

    private void Awake(){
        current = this;
    }

    void Start()
    {
        Pause();
        InstantiateToppingY = GameObject.Find("NewTopping").transform.position.y;
        //Listen to events
        Events.instantiateTopping.AddListener(InstantiateTopping);
        Events.resume.AddListener(Resume);
        Events.pause.AddListener(Pause);
        Events.mainMenu.AddListener(LoadMenu);
        Events.startGame.AddListener(StartGame);
        Events.playAgain.AddListener(PlayAgain);
        
    }

    public void Resume(){
        Time.timeScale = 1f;
        isPlaying = true;
    }

    void Pause(){
        Time.timeScale = 0f;
        isPlaying = false;
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Main");
    }

    public void StartGame(){   
        Resume(); 
    }

    public void PlayAgain(){
        //Add play again
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
}
