using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGoalTrigger : MonoBehaviour
{
    // for triggering a success or fail window/panel

    public StartManager startManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (startManager != null)
            {
                if (startManager.collectedCount >= startManager.requiredCollectibles)
                {
                    startManager.ShowSuccessPanel();
                }
                else
                {
                    startManager.ShowFailPanel();
                }
            }
        }
    }


}
