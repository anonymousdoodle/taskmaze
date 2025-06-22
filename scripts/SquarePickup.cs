using UnityEngine;

public class SquarePickup : MonoBehaviour
{
    // for collecting "square buddy collectibles"

    public int scoreValue = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ScoreManager>().AddScore(scoreValue);
            FindObjectOfType<StartManager>().AddCollectible();
            Destroy(gameObject);
        }
    }

}
