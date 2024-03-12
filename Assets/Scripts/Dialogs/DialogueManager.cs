using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

//such as the DialogueTrigger script this was taken from https://www.youtube.com/watch?v=_nRzoTzeyxU with adaptation to our needs
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText; //for displaying the sentences on the screen
    public Image scrol;
    //We uses queue for the FIFO attribute, this queue holds the lines that needs to be display
    private Queue<DialogueLine> sentences;
    private DialogueLine lineToDisplay;

    void Awake()
    {
        sentences = new Queue<DialogueLine>(); //initial the queue
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("starting dialogie");

        sentences.Clear(); //each time we start a new dialogue we want to make sure the queue is empty

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
        //each time before we want to display the next sentence we want to check if the sentence that is now displaying has an event to do
        if(lineToDisplay != null)
        {
            //in the new scene event we just load the scene that is giving to us from the unity controller
            if(lineToDisplay.dialogEvent.eventType == "New Scene")
            {
                NewSceneEvent();
            }

            //in end conversation event we want to stop displaying the conversation and disable the component responsible for
            //displaying the next sentence so that if the player will press the key for the next sentence it won't do anything.
            if(lineToDisplay.dialogEvent.eventType == "End Conversation")
            {
                EndConversationEvent();
                return;
            }

            //in Disable Component event we just want to disable the component giving us from the unity controller
            if(lineToDisplay.dialogEvent.eventType == "Disable Component")
            {
                DisableComponentEvent();
            }

            //in Enable Component event we just want to enable the component giving us from the unity controller
            if(lineToDisplay.dialogEvent.eventType == "Enable Component")
            {
                EnableComponentEvent();
            }
        }

        if(sentences.Count == 0)
        {
            Debug.Log("there are no more sentences");
            EnableDialogue();
            return;
        }
        lineToDisplay = sentences.Dequeue();
        dialogueText.text = "";
        Debug.Log(lineToDisplay.sentence);
        if(lineToDisplay.name != null)
        {
            nameText.text = lineToDisplay.name;
        }
        StopAllCoroutines();
        if(lineToDisplay.dialogEvent.eventType == "Option Answers")
        {
            OptionChoiceEvent();
        }
        else
        {
            StartCoroutine(TypeSentence(lineToDisplay.sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        //we use the IEnumerator so we can use the WaitForSeconds so we can display the letters one by one
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
        StopAllCoroutines();
        dialogueText.text = "";
        nameText.text = "";
        scrol.enabled = false; 
    }

    public void displayScrol()
    {
        scrol.enabled  = true;
    }

    public void UnDisplayScrol()
    {
        scrol.enabled = false;
        nameText.text = "";
        dialogueText.text = "";
    }

    private void NewSceneEvent()
    {
        SceneManager.LoadScene(lineToDisplay.dialogEvent.sceneName);
    }

    private void EndConversationEvent()
    {
        GameObject objectComponent = GameObject.Find(lineToDisplay.dialogEvent.objectComponent);
        // Get the component type based on its name
        Type componentType = Type.GetType(lineToDisplay.dialogEvent.componentName);
        if (componentType != null)
        {
            // Get the component from the objectComponent
            Component component = objectComponent.GetComponent(componentType);
            if (component != null && component is Behaviour)
            {
                // Enable or disable the component
                (component as Behaviour).enabled = false;
            }
            else
            {
                Debug.LogWarning("Component not found or is not a Behaviour: " + lineToDisplay.dialogEvent.componentName);
            }
        }
        else
        {
            Debug.LogWarning("Component type not found: " + lineToDisplay.dialogEvent.componentName);
        }
        lineToDisplay = null;
        EnableDialogue();
    }

    private void DisableComponentEvent()
    {
        GameObject objectComponent = GameObject.Find(lineToDisplay.dialogEvent.objectComponent);
        (objectComponent.GetComponent(lineToDisplay.dialogEvent.componentName) as Behaviour).enabled = false;
    }

    private void EnableComponentEvent()
    {
        // Find the GameObject by name
        GameObject obj = GameObject.Find(lineToDisplay.dialogEvent.objectComponent);

        if (obj != null)
        {
            // Try to get the component by name
            Component component = obj.GetComponent(lineToDisplay.dialogEvent.componentName);

            if (component != null)
            {
                // Try to get the MethodInfo for the function by name
                System.Reflection.MethodInfo methodInfo = component.GetType().GetMethod(lineToDisplay.dialogEvent.functionName);

                if (methodInfo != null)
                {
                    // Invoke the function on the component
                    methodInfo.Invoke(component, null);
                }
                else
                {
                    Debug.LogError("Function not found: " + lineToDisplay.dialogEvent.functionName);
                }
            }
            else
            {
                Debug.LogError("Component not found: " + lineToDisplay.dialogEvent.componentName);
            }
        }
        else
        {
            Debug.LogError("GameObject not found: " + lineToDisplay.dialogEvent.objectComponent);
        }
    }    

    private void OptionChoiceEvent()
    {
        FindObjectOfType<StartTalking>().OptionAnswersEventStart();
        foreach(OptionAnswer answer in lineToDisplay.dialogEvent.myAnswers)
        {
            answer.btn.onClick.RemoveAllListeners();
            answer.btn.GetComponentInChildren<TextMeshProUGUI>().text = answer.txt;
            answer.btn.interactable = true;
        }

        foreach (OptionAnswer answer in lineToDisplay.dialogEvent.myAnswers)
        {
            // Add a click event handler to the button
            answer.btn.onClick.AddListener(() => OnButtonClick(answer));
        }
    }

    private void OnButtonClick(OptionAnswer answer)
    {
        // Determine which button was pressed based on the OptionAnswer object
        Button pressedButton = answer.btn;
        string buttonText = answer.txt;

        Debug.Log("Button pressed: " + buttonText);

        // Perform actions based on the pressed button
        if (answer.isTheRightAnswer)
        {
            foreach(OptionAnswer answerO in lineToDisplay.dialogEvent.myAnswers)
            {
                answerO.btn.GetComponentInChildren<TextMeshProUGUI>().text = "";
                answerO.btn.interactable = false;
            }
            nameText.text = "";
            FindObjectOfType<StartTalking>().OptionAnswersEventEnd();
            // Handle the right answer
            DisplayNextSentence();
        }
        else
        {
            // Handle a wrong answer
            nameText.text = "";

            // Disable buttons temporarily while displaying wrong answer response
            foreach (OptionAnswer answerO in lineToDisplay.dialogEvent.myAnswers)
            {
                answerO.btn.interactable = false;
            }

            StartCoroutine(DisplayWrongAnswerAndReenableButtons(answer.wrongAnswerResponse));
        }
    }

    private IEnumerator DisplayWrongAnswerAndReenableButtons(string wrongAnswerResponse)
    {
        dialogueText.text = "";
        foreach (OptionAnswer answerO in lineToDisplay.dialogEvent.myAnswers)
        {
            answerO.btn.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

        // Display wrong answer response
        yield return StartCoroutine(TypeSentence(wrongAnswerResponse));

        // Wait for a while after displaying wrong answer response
        yield return new WaitForSecondsRealtime(2f);

        dialogueText.text = "";
        // Reenable buttons after a delay
        foreach (OptionAnswer answerO in lineToDisplay.dialogEvent.myAnswers)
        {
            answerO.btn.GetComponentInChildren<TextMeshProUGUI>().text = answerO.txt;
            answerO.btn.interactable = true;
        }

        if(lineToDisplay.name != null)
        {
            nameText.text = lineToDisplay.name;
        }
    }
}