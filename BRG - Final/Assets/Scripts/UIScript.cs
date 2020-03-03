using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    public GameObject mainMenuUI;
    public GameObject gameplayUI;
    //Play - pause button
    public Button pauseResumeButton;
    public Sprite pauseSprite;
    public Sprite playSprite;
    //Score
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //Listen to events
        Events.gameOver.AddListener(GameOver);
        Events.increaseScore.AddListener(IncreaseScore);
        Events.playAgainUI.AddListener(PlayAgain);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            ResumeOrPause();
        }
    }

    private void IncreaseScore(){
        scoreText.text = GameLogicScript.score.ToString(); 
    }

    public void ResumeOrPause(){
        if(GameLogicScript.isPlaying){
            Pause();
        }
        else{
            Resume();
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
        pauseResumeButton.GetComponent<Image>().sprite = pauseSprite;
        Events.resume.Invoke();
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        gameOverMenuUI.SetActive(false);
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
        pauseResumeButton.GetComponent<Image>().sprite = playSprite;
        Events.pause.Invoke();
    }

    public void GoToMenu(){
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
        gameplayUI.SetActive(false);
        Events.mainMenu.Invoke();
    }

    public void StartGame(){
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
        Events.startGame.Invoke();
    }

    public void PlayAgain(){
        Debug.Log("Holiwis");
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
    }

    public void PlayAgainForButton(){
        Events.playAgainGameLogic.Invoke();
    }

    public void GameOver(){
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        Events.pause.Invoke();
    }

}
