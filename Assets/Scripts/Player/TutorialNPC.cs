using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

[System.Serializable]
public class DialoguePoint
{
    public Transform point;
    public string sentence;
    public bool isDone = false;
}

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
        foreach (char letter in dialoguePoints[pointIndex].sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        dialoguePoints[pointIndex].isDone = true;
        yield return new WaitForSeconds(2f);
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