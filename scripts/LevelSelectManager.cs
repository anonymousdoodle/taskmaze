using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    // for the button level transparency/or for when player completes a level
    // transparent button goes to normal upon completing a certain level

    public Button[] levelButtons;


    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < unlockedLevel)
            {
                levelButtons[i].interactable = true;
                levelButtons[i].image.color = Color.white; 
            }
            else
            {
                levelButtons[i].interactable = false;
                Color c = levelButtons[i].image.color;
                c.a = 0.5f;
                levelButtons[i].image.color = c;
            }
        }
    }

    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }
}
