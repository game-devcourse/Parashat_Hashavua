using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneTrigger : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] string triggerTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggerTag) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
