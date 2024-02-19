using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public string nextSceneName;

    private void Start()
    {
        // Ensure the next scene name is not empty
        
    }

    // private void Update()
    // {
    //     // Check for button click
    //     if (Input.GetButtonDown("Fire1")) // You may need to customize this based on your input settings
    //     {
    //         // Call a function to transition to the next scene
    //         TransitionToNextScene();
    //     }
    // }

    public void OnClick()
    {
        if (string.IsNullOrEmpty(nextSceneName))
        {
            Debug.LogError(nextSceneName);
            
            Debug.LogError("Next scene name is not set!");
        }
        else
        {
            TransitionToNextScene();

        }
    }

    private void TransitionToNextScene()
    {
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
