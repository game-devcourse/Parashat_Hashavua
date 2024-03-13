using UnityEngine;
using TMPro;
using System.Collections; // Add this line

public class InstructionDisplay : MonoBehaviour
{
    public TMP_Text instructionsText;
    public float displayDuration = 5f;

    void Start()
    {
        // Check if instructionsText is assigned
        if (instructionsText != null)
        {
            // Set the text to be initially visible
            instructionsText.enabled = true;

            // Use a coroutine to hide the text after the specified duration
            StartCoroutine(HideInstructionsAfterDelay(displayDuration));
        }
        else
        {
            Debug.LogError("Instructions Text not assigned!");
        }
    }

    IEnumerator HideInstructionsAfterDelay(float delay)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delay);

        // Hide the instructionsText
        instructionsText.enabled = false;
    }
}