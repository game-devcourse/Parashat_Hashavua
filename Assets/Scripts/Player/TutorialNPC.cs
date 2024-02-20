using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

public class TutorialNPC : TargetMover
{
    public Transform[] pointsOfInterest;
    public string[] dialogue;
    public TextMeshProUGUI dialogueText;
    private bool[] doneExplanations;
    private int currentPoint = 0;
    private bool isExplaining = false;

    // Recieve the input key for the player to press to continue the explanation
    // and the text to display for the explanation
    public InputAction continueButton;

    void Start()
    {
        doneExplanations = new bool[pointsOfInterest.Length];
        for(int i=0; i<doneExplanations.Length; i++)
        {
            doneExplanations[i] = false;
        }
        SetTarget(pointsOfInterest[currentPoint].position);
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
        for (int i = 0; i < pointsOfInterest.Length; i++)
        {
            if (!isExplaining && Vector3.Distance(transform.position, pointsOfInterest[i].position) <= 8f && !doneExplanations[i])
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
        foreach (char letter in dialogue[pointIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        isExplaining = false;
        doneExplanations[pointIndex] = true;
        yield return new WaitUntil(() => continueButton.triggered);
        dialogueText.text = ""; // Clear text after explanations
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        if (currentPoint < pointsOfInterest.Length - 1)
        {
            currentPoint++;
            SetTarget(pointsOfInterest[currentPoint].position);
        }
    }
}