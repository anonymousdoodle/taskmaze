using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject pauseButtonCanvas; 


    // for the pause button, pauses the game
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        pauseButtonCanvas.SetActive(false); 
    }

    // for the continue button in the pause panel, resumes from when the game left off
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        pauseButtonCanvas.SetActive(true); 
    }

}
