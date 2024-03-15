using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class WarningOnTrigger : MonoBehaviour
{
    public TextMeshProUGUI dialogueText = null; //for displaying the sentences on the screen
    public Image scrol = null;
    public string sentenceToDisplay;
    public string triggerTag;
    public GameObject[] blocks = null;
    public Vector3 pushing;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == triggerTag)
        {
            scrol.enabled = true;
            dialogueText.text = sentenceToDisplay;
            GameObject PushingObject = GameObject.FindWithTag(triggerTag);
            PushingObject.transform.position -= pushing;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == triggerTag)
        {
            scrol.enabled = false;
            dialogueText.text = "";
        }
    }

    public void TurnOffWarnings()
    {
        transform.GetComponent<Collider2D>().enabled = false;
        foreach(GameObject block in blocks)
        {
            block.SetActive(false);
        }
    }

    public void TurnOnWarnings()
    {
        transform.GetComponent<Collider2D>().enabled = true;
    }
}
