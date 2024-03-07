using UnityEngine;

public class FreshFoodController : MonoBehaviour
{
   // [SerializeField] Timer timer;
    // This function is called when the collider of the fresh food interacts with another collider.
    // void Start()
    // {
    //     timer.startState();
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the interacting collider is the player.
        if (other.CompareTag("Player"))
        {
            // Handle interaction with fresh food (e.g., increase score).
            // You can add your scoring logic or any other action here.
            Debug.Log("Player collected fresh food!");
            
            // Optionally, you can destroy the fresh food object after interaction.
            Destroy(gameObject);
        }
    }
}