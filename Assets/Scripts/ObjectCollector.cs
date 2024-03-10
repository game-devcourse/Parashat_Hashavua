using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] public string triggeringTag;
    [SerializeField] public NumberField scoreField;
    [SerializeField] string sceneName;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && scoreField!=null) {
            Destroy(other.gameObject);
        }
    }

    public void SetScoreField(NumberField newTextField) {
        this.scoreField = newTextField;
    }
}
