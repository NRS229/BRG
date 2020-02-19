using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public Button pauseResumeButton;
    public Sprite pauseSprite;
    public Sprite playSprite;
    
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
}
