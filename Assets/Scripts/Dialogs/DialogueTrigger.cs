using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//taken from https://www.youtube.com/watch?v=_nRzoTzeyxU with adaptation to our needs
[System.Serializable]
public class DialogueLine
{
    public string name;
    public string sentence; //to hold the sentence we want to display
    /**
    *this next parameter is to manage what will happen after the this dialogue(line) will finish, we are using in tuple so we can
    *manage events that needs to activate other thing.
    *the options are:
    **<"End Conversation", component> - we want to get a component to disable, this option is meant to be for ending conversation temporarly.
    *<"New Scene">, "sceneName">
    *<"Disable Component", component>
    *<"Enable Component",  component, functionName>
    *<"Option Answers", an array of buttons>
    *We decide to make the type as an object so we can get verious types such as components, string, game object etc.
    **/
    public DialogueEvent dialogEvent;
}

[System.Serializable]
public class DialogueEvent
{
    public string eventType;
    public string sceneName;
    public string objectComponent;
    public string componentName;
    public string functionName;
    public OptionAnswer[] myAnswers;
}

//a new struct to contain the buttons the struct will be build out of UIbutton, 
//a boolean attribute that says if this is the correct answer or not(for option which there is a right answer),
//the text that should be appeard on the button,
//and what will be appear if the player will choose the wrong answer.
[System.Serializable]
public class OptionAnswer
{
    public Button btn = null;
    public bool isTheRightAnswer;
    public string txt;
    public string wrongAnswerResponse;
}

//a dialogue object to hold all the lines
[System.Serializable]
public class Dialogue
{
    public DialogueLine[] dialogueLines;
}

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
