using UnityEngine;
using TMPro;

public class RottenFoodConroller : MonoBehaviour
{
    public int maxRottenFoodCount = 3;
    private static int currentRottenFoodCount = 0;

    public TMP_Text disqualificationMessage;

    private void Start()
    {
        HideDisqualificationMessage(); // Call the hide function when the game starts
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentRottenFoodCount++;

            Debug.Log("Rotten Food Count: " + currentRottenFoodCount);

            if (currentRottenFoodCount >= maxRottenFoodCount)
            {
                Debug.Log("Player disqualified!");
                ShowDisqualificationMessage();
                DisqualifyPlayer();
            }

            Destroy(gameObject); // Destroy the rotten food object after collision (optional)
        }
    }

    private void ShowDisqualificationMessage()
    {
        if (disqualificationMessage != null)
        {
            disqualificationMessage.gameObject.SetActive(true); // Show the TextMeshPro object
            Invoke("HideDisqualificationMessage", 2f); // Hide the message after 2 seconds
        }
    }

    private void HideDisqualificationMessage()
    {
        if (disqualificationMessage != null)
        {
            disqualificationMessage.gameObject.SetActive(false); // Hide the TextMeshPro object
            currentRottenFoodCount = 0; // Reset the count when hiding the message
        }
    }

    private void DisqualifyPlayer()
    {
        // Reset the rotten food count before restarting the game
        currentRottenFoodCount = 0;

        Debug.Log("Restarting game...");
        RestartGame();
    }

    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}