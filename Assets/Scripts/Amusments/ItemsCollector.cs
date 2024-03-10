using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollector : ObjectCollector
{
    [SerializeField] string wrongItemsTag;
    [SerializeField] NumberField wrongScoreField;
    [SerializeField] Timer timer;
    [SerializeField] GameObject coinManager;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject gameoverFalseCollectText;

    void Start()
    {
        winText.SetActive(false);
        gameoverFalseCollectText.SetActive(false);
        GetComponent<KeyboardMoverByTile>().enabled = true;
        timer.startState();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && scoreField!=null) {
            Destroy(other.gameObject);
            scoreField.AddNumber(1);
        }

        if(other.tag == wrongItemsTag && wrongScoreField != null)
        {
            Destroy(other.gameObject);
            wrongScoreField.AddNumber(1);
        }

        if(wrongScoreField.GetNumber() >= 3)
        {
            //show game over screen
            gameoverFalseCollectText.SetActive(true);
            GetComponent<KeyboardMoverByTile>().enabled = false;
            timer.stopTime();
        }

        if(scoreField.GetNumber() >= 10)
        {
            //show win screen
            winText.SetActive(true);
            // Check if coinManager is null before accessing its components
            if (coinManager != null) {
                Debug.Log("the coin manager isnt null");
                coinManager.GetComponent<CoinsManager>().AddNumber(20);
            } else {
                Debug.LogWarning("coinManager is not assigned.");
            }
            GetComponent<KeyboardMoverByTile>().enabled = false;
            timer.stopTime();
        }
    }

    public void SetWrongScoreField(NumberField newTextField) {
        this.wrongScoreField = newTextField;
    }
}
