// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class CoinsManager : MonoBehaviour
// {
//     [SerializeField] TextMeshProUGUI  coinText;
//     [SerializeField] int addCoin;

//     private int coins = 0;

//     public Add()
//     {
//         coins += addCoin;
//     }


// }

using TMPro;
using UnityEngine;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */
// [RequireComponent(typeof(TextMeshProUGUI))]
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