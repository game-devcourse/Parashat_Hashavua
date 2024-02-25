using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

[System.Serializable]
public class DialoguePoint
{
    public Transform point;
    public string[] sentences;
    public bool isDone = false;
}

//this script was alternate from the script of Ofek Rotem and Yoni Tal
//https://github.com/Mishakim-Lamahshev/Avatar-Shadows-Of-Harmony/blob/main/Assets/Scripts/TutorialNPC.cs
public class TutorialNPC : TargetMover
{
    [SerializeField] TextMeshProUGUI dialogueText;
    
    [SerializeField] DialoguePoint[] dialoguePoints;

    private int currentPoint = 0;
    private bool isExplaining = false;

    // Recieve the input key for the player to press to continue the explanation
    // and the text to display for the explanation
    public InputAction continueButton;

    void Start()
    {
        SetTarget(dialoguePoints[currentPoint].point.position);
        continueButton.Enable();
        base.Start();
    }

    void OnEnable()
    {
        continueButton.Enable();
    }

    void OnDisable()
    {
        continueButton.Disable();
    }

    void Update()
    {
        for (int i = 0; i < dialoguePoints.Length; i++)
        {
            if (!isExplaining && Vector3.Distance(transform.position, dialoguePoints[i].point.position) <= 8f && !dialoguePoints[i].isDone)
            {
                StartCoroutine(ShowPlayerExplanation(i));
                break; // Exit the loop to ensure only one explanation starts.
            }
        }
    }

    IEnumerator ShowPlayerExplanation(int pointIndex)
    {
        isExplaining = true;
        dialogueText.text = ""; // Clear previous text
        foreach(string sentence in dialoguePoints[pointIndex].sentences)
        {
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.1f);
            }
            dialogueText.text += "\n";
            yield return new WaitForSeconds(2f);
        }

        dialoguePoints[pointIndex].isDone = true;
        isExplaining = false;
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        if (currentPoint < dialoguePoints.Length - 1)
        {
            currentPoint++;
            SetTarget(dialoguePoints[currentPoint].point.position);
        }
    }
}