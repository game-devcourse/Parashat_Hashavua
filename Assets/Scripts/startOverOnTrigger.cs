using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class startOverOnTrigger : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;
    [SerializeField] string sceneName;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            Debug.Log("Game over!");
            other.transform.position = Vector3.zero;
            SceneManager.LoadScene(sceneName);
        }
    }
}
