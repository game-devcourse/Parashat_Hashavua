using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SheepCollector : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] NumberField scoreField;
    [SerializeField] string sceneName;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && scoreField!=null) {
            scoreField.AddNumber(1);
            Destroy(other.gameObject);
        }

        // Check if the score reaches 7
        if (scoreField.GetNumber() >= 7)
        {
            // Load the final scene
            SceneManager.LoadScene(sceneName);
        }
    }

    public void SetScoreField(NumberField newTextField) {
        this.scoreField = newTextField;
    }
}
