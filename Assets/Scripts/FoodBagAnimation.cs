using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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
    public GameObject[] soldiers;
    public GameObject takenObject;
    public Transform goBackPoint;
    public float speed;
    public StartTalking talk;
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
        talk.Disable();
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
        yield return new WaitForSeconds(1.5f);
        foodBags[2].transform.position = positionBags[2];
        yield return new WaitForSeconds(1f);

        takenObject.transform.SetParent(soldiers[0].transform);
        takenObject.transform.position = checkPoint.position;
        foreach(GameObject soldier in soldiers)
        {
            soldier.transform.position = Vector3.MoveTowards(soldier.transform.position, goBackPoint.position, speed * Time.deltaTime);
        }
        yield return new WaitForSeconds(3f);
        
        SceneManager.LoadScene(sceneName);
    }
}