using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningOnTrigger : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; //for displaying the sentences on the screen
    public Image scrol;
    public string sentenceToDisplay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        scrol.enabled = true;
        dialogueText.text = sentenceToDisplay;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        scrol.enabled = false;
        dialogueText.text = "";
    }

    public void TurnOffWarnings()
    {
        transform.GetComponent<Collider2D>().enabled = false;
    }

    public void TurnOnWarnings()
    {
        transform.GetComponent<Collider2D>().enabled = true;
    }
}
