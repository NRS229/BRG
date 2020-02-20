using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GameOverMenuUI;
    public Button pauseResumeButton;
    public Sprite pauseSprite;
    public Sprite playSprite;
    
    void Start()
    {
        //Listen to events
        Events.gameOver.AddListener(GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            ResumeOrPause();
        }
        
    }

    public void ResumeOrPause(){
        if(isPaused){
            Resume();
        }
        else{
            Pause();
        }
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        pauseResumeButton.GetComponent<Image>().sprite = pauseSprite;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pauseResumeButton.GetComponent<Image>().sprite = playSprite;
    }

    public void LoadMenu(){
        Debug.Log("Load menu pressed"); 
    }

    public void Restart(){
        SceneManager.LoadScene("Main");   
        Resume(); 
    }

    public void GameOver(){
        Time.timeScale = 0f;
        isPaused = true;
        pauseResumeButton.gameObject.SetActive(false);
        GameOverMenuUI.SetActive(true);
    }
}
