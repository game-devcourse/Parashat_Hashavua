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
    *<"Attach Objects", parent object, child object>
    *We decide to make the type as an object so we can get verious types such as components, string, game object etc.
    **/
    public DialogueEvent dialogEvent;
}

//A dialogue event class to handle all kind of evvents
[System.Serializable]
public class DialogueEvent
{
    public string eventType;
    public string sceneName; //-> New Scene event
    public string objectComponent; //-> Enable Component event, -> Disable Component event, -> End Conversation event
    public string componentName; //-> Enable Component event, -> Disable Component event, -> End Conversation event
    public string functionName; //-> Enable Component event, -> Disable Component event
    public string ParentTag; //-> Attach Objects event
    public string ChildTag; //-> Attach Objects event
    public OptionAnswer[] myAnswers; //-> Option Answers event
}

//a new struct to contain the buttons the struct will be build out of UIbutton, 
//a boolean attribute that says if this is the correct answer or not(for option which there is a right answer),
//the text that should be appeard on the button,
//what will be appear if the player will choose the wrong answer,
//and an event type to manage what will happen after a wrong answer was pressed. The event is the same as the event types above except for the Option Answers event.
[System.Serializable]
public class OptionAnswer
{
    public Button btn = null;
    public bool isTheRightAnswer;
    public string txt;
    public string wrongAnswerResponse;
    public string eventType;
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