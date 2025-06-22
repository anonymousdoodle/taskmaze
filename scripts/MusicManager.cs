using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;


    // to keep music playing during the gameplay
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
