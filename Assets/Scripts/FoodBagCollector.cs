using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using System;

public class FoodBagCollector : ObjectCollector
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText; //for displaying the sentences on the screen
    public Image scrol;
    public string sentenceToDisplay;
    public string name;
    [SerializeField] InputAction continueButton = new InputAction(type: InputActionType.Button);

    private int bagsCollected = 0;
    private bool finishCollecting = false;

        void OnEnable()
    {
        continueButton.Enable();
    }

    void OnDisable()
    {
        continueButton.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag) {
            Destroy(other.gameObject);
            bagsCollected++;
        }

        if(bagsCollected == 4)
        {
            finishCollecting = true;
            scrol.enabled = true;
            nameText.text = name;
            dialogueText.text = sentenceToDisplay;
            // TypeSentence(sentenceToDisplay);
        }
    }

    // IEnumerator TypeSentence(string sentence)
    // {
    //     //we use the IEnumerator so we can use the WaitForSeconds so we can display the letters one by one
    //     foreach(char letter in sentence.ToCharArray())
    //     {
    //         dialogueText.text += letter;
    //         yield return new WaitForSeconds(0.1f);
    //     }
    // }

    void Update()
    {
        if (continueButton.WasPressedThisFrame() && finishCollecting) 
        {
            StopAllCoroutines();
            dialogueText.text = "";
            nameText.text = "";
            scrol.enabled = false;
        }
    }

}
