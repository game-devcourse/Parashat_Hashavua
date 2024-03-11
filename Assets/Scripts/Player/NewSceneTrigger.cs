using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneTrigger : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] string triggerTag;
    [SerializeField] GameObject coinManager = null;
    [Tooltip("If the current scene is a game that should add coins, enable it.")]
    [SerializeField] bool isGame;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggerTag) {
            if(isGame)
            {
                // Check if coinManager is null before accessing its components
                if (coinManager != null) {
                    coinManager.GetComponent<CoinsManager>().AddNumber(20);
                } else {
                    Debug.LogWarning("coinManager is not assigned.");
                }
            }
            SceneManager.LoadScene(sceneName);
        }
    }
}
