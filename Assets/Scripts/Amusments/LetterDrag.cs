using UnityEngine;

public class LetterDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;

    void OnMouseDown()
    {
        isDragging = true;
        offset = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        isDragging = false;
        CheckWordFormation();  // Check word formation when the mouse is released
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }

    void CheckWordFormation()
    {
        // Implement logic to check if the letters are in the correct order (חלומות)
        // You may want to compare the positions of the letter GameObjects or use colliders.

        // For simplicity, let's assume each letter has a designated position
        Vector2[] correctPositions = new Vector2[]
        {
            new Vector2(0, 0),  // ח
            new Vector2(1, 0),  // ל
            new Vector2(2, 0),  // ו
            new Vector2(3, 0),  // ו
            new Vector2(4, 0),  // ת
            new Vector2(5, 0),  // מ
        };

        // Tolerance for position matching
        float positionTolerance = 0.5f;

        // Check if each letter is close enough to its correct position
        bool wordFormed = true;
        for (int i = 0; i < correctPositions.Length; i++)
        {
            float distance = Vector2.Distance((Vector2)transform.position, correctPositions[i]);
            if (distance >= positionTolerance)
            {
                // At least one letter is not in the correct position
                wordFormed = false;
                break;
            }
        }

        // React based on word formation
        if (wordFormed)
        {
            WordFormedAction();  // You can define a function to handle the word formed event
        }
    }

    void WordFormedAction()
    {
        // Implement actions when the word is correctly formed
        Debug.Log("Word חלומות correctly formed!");
        // Add your desired actions here, such as showing a message, playing a sound, etc.
    }
}
