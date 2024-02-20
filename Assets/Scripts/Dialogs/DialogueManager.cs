using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//such as the DialogueTrigger script this was taken from https://www.youtube.com/watch?v=_nRzoTzeyxU with adaptation to our needs
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText; //for displaying the sentences on the screen
    //We uses queue for the FIFO attribute, this queue holds the lines that needs to be display
    private Queue<DialogueLine> sentences;
    private DialogueLine lineToDisplay;

    void Start()
    {
        sentences = new Queue<DialogueLine>(); //initial the queue
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("starting dialogie");

        sentences.Clear(); //in order to make sure the queue is empty when starting a new dialogue

        //sentences.Clear(); //each time we start a new dialogue we want to make sure the queue is empty
        if(sentences.Count > 0)
        {
            DisplayNextSentence();
        }

        //enter the lines one by one into the queue
        foreach(DialogueLine line in dialogue.dialogueLines)
        {
            sentences.Enqueue(line);
        }

        //start displaying
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(lineToDisplay != null)
        {
            if(lineToDisplay.exitScene != null)
            {
                SceneManager.LoadScene(lineToDisplay.exitScene);
            }
        }

        if(sentences.Count == 0)
        {
            EnableDialogue();
            return;
        }

        lineToDisplay = sentences.Dequeue();
        Debug.Log(lineToDisplay.sentence);
        if(lineToDisplay.name != null)
        {
            nameText.text = lineToDisplay.name;
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(lineToDisplay.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void EnableDialogue()
    {
        Debug.Log("End of dialogue.");
    }
}