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
    [SerializeField] int coinsWin; // how many coins the player win in the game

    void Start()
    {
        winText.SetActive(false);
        gameoverFalseCollectText.SetActive(false);
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

        //Manage the lose state
        if(wrongScoreField.GetNumber() >= 3)
        {
            //show game over screen
            gameoverFalseCollectText.SetActive(true);
            GetComponent<KeyboardMover>().enabled = false;
            timer.stopTime();
        }

        //Manage the win state
        if(scoreField.GetNumber() >= 10)
        {
            //show win screen
            winText.SetActive(true);
            // Check if coinManager is null before accessing its components
            if (coinManager != null) {
                Debug.Log("the coin manager isnt null");
                coinManager.GetComponent<CoinsManager>().AddNumber(coinsWin);
            } else {
                Debug.LogWarning("coinManager is not assigned.");
            }
            //Once the game is over, whether the player won or lose its mover component will disable so he won't be able to move
            GetComponent<KeyboardMover>().enabled = false;
            timer.stopTime();
        }
    }

    public void SetWrongScoreField(NumberField newTextField) {
        this.wrongScoreField = newTextField;
    }
}