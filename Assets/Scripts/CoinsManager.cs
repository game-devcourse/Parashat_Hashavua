using TMPro;
using UnityEngine;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */
public class CoinsManager : MonoBehaviour {
    private static int number = 0;

    public int GetNumber() {
        return number;
    }

    public void SetNumber() {
        Debug.Log(number);
        GetComponent<TextMeshProUGUI>().text = number.ToString();
    }

    public void AddNumber(int toAdd) {
        number += toAdd;
        SetNumber();
    }

    void Start()
    {
        SetNumber();
    }
}