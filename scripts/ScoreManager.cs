using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int currentScore = 0;
    public Text scoreText;

    private int levelStartScore = 0;

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // for scene changes, saves score without resetting
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject foundText = GameObject.Find("ScoreText");
        if (foundText != null)
        {
            scoreText = foundText.GetComponent<Text>();
        }
        // saves score from start level to current level
        // for every time the player completes a level with its score
        // the current score increases for every square buddy collectible

        levelStartScore = currentScore; 
        UpdateScoreText();
    }

    public void ResetToLevelStartScore()
    {
        currentScore = levelStartScore; // resets the score to its default/current score (retry button)
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreText(); // increases the score
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore.ToString(); // updates the score
    }


}
