using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FoodBagAnimation : MonoBehaviour
{
    public GameObject Goblet;
    public GameObject[] foodBags;
    public Transform checkPoint;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameDisplay;
    public string sentence;
    public string name;
    public Image scrol;
    public string sceneName;

    private Vector3[] positionBags;

    void Start()
    {
        Goblet.SetActive(false);
        positionBags = new Vector3[foodBags.Length];
        positionBags[0] = foodBags[0].transform.position;
        positionBags[1] = foodBags[1].transform.position;
        positionBags[2] = foodBags[2].transform.position;
    }

    public void moveBags()
    {
        Debug.Log("the bags are start moving");
        StartCoroutine(GoCheck());
    }

    IEnumerator GoCheck()
    {
        for (int index = 0; index < 2; index++)
        {
            foodBags[index].transform.position = checkPoint.position;
            yield return new WaitForSeconds(1.5f);
            foodBags[index].transform.position = positionBags[index];
            yield return new WaitForSeconds(1f);
        }
        foodBags[2].transform.position = checkPoint.position;
        yield return new WaitForSeconds(1.5f);
        Goblet.SetActive(true);
        scrol.enabled = true; 
        textDisplay.text = sentence;
        nameDisplay.text = name;
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneName);
    }
}