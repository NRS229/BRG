using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicScript : MonoBehaviour
{
    //Cameras
    public GameObject menuCamera;
    public GameObject gameplayCamera;
    //Bool
    public static bool isPlaying = false;
    public static bool playAgain = false;
    //Float
    private float InstantiateToppingY;
    //GameObject
    private GameObject NextTopping;
    public GameObject NewToppingPrefab;
    //Others
    public Sprite[] ToppingSprites;
    
    void Start(){
        
        InstantiateToppingY = -2;
        //Listen to events
        Events.instantiateTopping.AddListener(InstantiateTopping);
        Events.resume.AddListener(Resume);
        Events.pause.AddListener(Pause);
        Events.mainMenu.AddListener(LoadMenu);
        Events.startGame.AddListener(StartGame);
        Events.playAgainGameLogic.AddListener(PlayAgain);
        
        if(playAgain){
            Debug.Log("Invoked event");
            Events.playAgainUI.Invoke();
            StartGame();
            
        }
        else
            Pause();
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
        playAgain = false;
    }

    public void StartGame(){   
        Resume(); 
        menuCamera.gameObject.SetActive(false);
        gameplayCamera.gameObject.SetActive(true);
        playAgain = false;
    }

    public void PlayAgain(){
        playAgain = true;
        SceneManager.LoadScene("Main");
    }

    private void InstantiateTopping()
    {
        float x = transform.position.x + Random.Range(14, 20);
        NextTopping = Instantiate(NewToppingPrefab, new Vector2(x, InstantiateToppingY), Quaternion.identity) as GameObject;
        NextTopping.name = "NewTopping";
        //Delete "* 1.15f" when modifying sprite
        InstantiateToppingY += NextTopping.GetComponent<BoxCollider2D>().size.y * 1.15f;
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
