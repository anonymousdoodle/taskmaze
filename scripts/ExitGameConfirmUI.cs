using UnityEngine;

//gives player options to exit
public class ExitGameConfirmUI : MonoBehaviour
{
    public GameObject exitConfirmPanel;

    private bool isQuitting = false;
    private float quitTimer = 0f;
    public float quitTimeout = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");

            if (!isQuitting)
            {
                isQuitting = true;
                quitTimer = quitTimeout;

                if (exitConfirmPanel != null)
                {
                    Debug.Log("Activating exitConfirmPanel");
                    exitConfirmPanel.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("exitConfirmPanel is null!");
                }
            }
            else
            {
                Debug.Log("Exiting game...");
                Application.Quit();
            }
        }

        if (isQuitting)
        {
            quitTimer -= Time.unscaledDeltaTime;

            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("Canceling quit with N key");
                CancelExit();
            }

            if (quitTimer <= 0f)
            {
                Debug.Log("Quit timer expired, canceling");
                CancelExit();
            }
        }
    }

    void CancelExit()
    {
        isQuitting = false;
        if (exitConfirmPanel != null)
            exitConfirmPanel.SetActive(false);
    }
}
