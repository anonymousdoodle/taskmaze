using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject successCanvas;
    public GameObject successPanel;
    public Text scoreTotalText; 

    public GameObject pauseButtonCanvas; 

    public GameObject winPanel;
    public GameObject howToPlayCanvas;

    public GameObject levelCanvas;     
    public GameObject levelPanel;      
    public GameObject menuPanel;      

    public GameObject backButton; 

    public GameObject pauseCanvas;

    public GameObject failCanvas;        
    public GameObject failPanel;        

    public int requiredCollectibles = 6; 
    public int collectedCount = 0;


    void Start()
    {
        PlayerPrefs.DeleteKey("UnlockedLevel");

        PlayerPrefs.DeleteKey("ShowMenu");
        string currentLevel = SceneManager.GetActiveScene().name;

        // keeps the menu from showing at the startup of the game
        // but not on levels 2-5 to keep the gameplay flow continue

        if (currentLevel == "level1" && PlayerPrefs.GetInt("ShowMenu", 0) == 0)
        {
            menuCanvas.SetActive(true);
            pauseButtonCanvas.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            menuCanvas.SetActive(false);
            pauseButtonCanvas.SetActive(true); 
            Time.timeScale = 1f;
        }
    }

    //shows the menu
    public void StartGame()
    {
        menuCanvas.SetActive(false);
        pauseButtonCanvas.SetActive(true);
        Time.timeScale = 1f;
    }
    // mazegoaltrigger code triggers this class to show the success after collecting each
    // square in the level
    public void ShowSuccessPanel()
    {
        successCanvas.SetActive(true);
        successPanel.SetActive(true);
        Time.timeScale = 0f;

        if (scoreTotalText != null)
        {
            scoreTotalText.text = "Score: " + ScoreManager.instance.currentScore;
        }
    }

    

    public void RedoLevel()
    {
        Time.timeScale = 1f;

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetToLevelStartScore(); // resets to level start score/default score
        }

        PlayerPrefs.SetInt("ShowMenu", 0);

        menuCanvas.SetActive(false);
        successCanvas.SetActive(false);
        successPanel.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void GoToMenu()
    {
        menuCanvas.SetActive(true);
        successCanvas.SetActive(false);
        successPanel.SetActive(false);
        winPanel.SetActive(false); // via/from win panel
        pauseButtonCanvas.SetActive(false);
        Time.timeScale = 0f;
    }


    // prevents the menu from reappearing after clicking the retry button from the pause button
    void OnEnable()
    {
        if (PlayerPrefs.GetInt("ShowMenu", 0) == 1 && SceneManager.GetActiveScene().name == "level1")
        {
            menuCanvas.SetActive(true);
            successCanvas.SetActive(false);
            successPanel.SetActive(false);
            Time.timeScale = 0f;

            PlayerPrefs.SetInt("ShowMenu", 0); 
        }
    }



    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        // save progress, from after completing a level
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) < nextIndex + 1)
        {
            PlayerPrefs.SetInt("UnlockedLevel", nextIndex + 1);
        }

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(nextIndex);
        }
    }

    // shows the you win window after completing the game
    public void ShowWinPanel()
    {
        successCanvas.SetActive(true);
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // goes back to level 1
    public void BackToLevelOne()
    {
        Time.timeScale = 1f;

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.currentScore = 0;
        }

        SceneManager.LoadScene("Level1");
    }

    // menu buttons
    public void ShowHowToPlay()
    {
        howToPlayCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    // from the howtoplay window
    public void BackToMenu()
    {
        howToPlayCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    
    public void BackToPausePanel()
    {
        levelPanel.SetActive(false);
        pauseCanvas.SetActive(true);
        pauseButtonCanvas.SetActive(false); // still paused
    }

    //shows back button from the pause panel
    // does not show anymore when going to the menu window

    public void ShowLevelPanelFromPause()
    {
        ShowLevelPanel(true); 
    }
    public void ShowLevelPanelFromMenu()
    {
        ShowLevelPanel(false); 
    }
    private void ShowLevelPanel(bool showBackButton)
    {
        levelCanvas.SetActive(true);
        levelPanel.SetActive(true);
        menuPanel.SetActive(false);
        successPanel.SetActive(false);
        pauseCanvas.SetActive(false);
        pauseButtonCanvas.SetActive(false);

       // for when the player finishes a level, goes to menu via success panel/window
       // then goes to levels panel/window again to show the recently unlocked level
        LevelSelectManager lsm = FindObjectOfType<LevelSelectManager>();
        if (lsm != null) lsm.RefreshButtons();

        if (backButton != null)
            backButton.SetActive(showBackButton);
    }





    public void BackToMenuFromLevels()
    {
        levelPanel.SetActive(false);
        levelCanvas.SetActive(false);

        menuCanvas.SetActive(true);
        menuPanel.SetActive(true);

        pauseCanvas.SetActive(false);
        successPanel?.SetActive(false);
        winPanel?.SetActive(false);
        pauseButtonCanvas.SetActive(false);

        Time.timeScale = 0f;
    }

    public void ShowFailPanel()
    {
        if (failCanvas != null) failCanvas.SetActive(true);
        if (failPanel != null) failPanel.SetActive(true);

        pauseButtonCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    // debug only, shows if every "square buddy" collectible is collected
    public void AddCollectible()
    {
        collectedCount++;

        if (collectedCount >= requiredCollectibles)
        {
            Debug.Log("All collectibles collected!");
        }
    }





}
