using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsSimulate : MonoBehaviour
{
    [SerializeField] GameObject[] Objects; // Array to hold the object
    [SerializeField] string sceneName; //the scene we want to move to once the player wins the game(aka catches all the objects)
    [SerializeField] Timer timer;
    [SerializeField] GameObject coinManager;
    [SerializeField] GameObject winText;

    private int currentObjectIndex = 0; // Index to track the current object
    private GameObject currentObject;
    private int objectsLeft;


    private void Start()
    {
        winText.SetActive(false);
        objectsLeft = Objects.Length;
        currentObject = Objects[currentObjectIndex]; //Instantiate(Objects[currentObjectIndex], transform.position, Quaternion.identity);
        currentObject.GetComponent<KeyboardMoverByTile>().enabled = true;
        currentObject.GetComponent<Catch>().SetCanCatch(true);
        for(int i=1; i<Objects.Length; i++)
        {
            Objects[i].GetComponent<KeyboardMoverByTile>().enabled = false;
            Objects[i].GetComponent<Catch>().SetCanCatch(false);
        }
        timer.startState();
    }

    private void switchObject()
    {
        //disabling the previous cow
        Objects[currentObjectIndex].GetComponent<Catch>().SetCanCatch(false);
        Objects[currentObjectIndex].GetComponent<KeyboardMoverByTile>().enabled = false;

        // Increment the index to move to the next object
        currentObjectIndex++;

        // Check if there are more objects to instantiate
        if (currentObjectIndex < Objects.Length)
        {
            // Instantiate the next object
            currentObject = Objects[currentObjectIndex]; //Instantiate(Objects[currentObjectIndex], transform.position, Quaternion.identity);
            //enabling the cuurent cow
            currentObject.GetComponent<KeyboardMoverByTile>().enabled = true;
            currentObject.GetComponent<Catch>().SetCanCatch(true);
        }
        else
        {
            Debug.Log("All objects collected!");
            // You can add your logic here for what should happen after all objects are collected
        }
    }

    void Update()
    {
        if(timer.isOutOfTime)
        {
            for(int i=0; i<Objects.Length; i++)
            {
                Objects[i].GetComponent<KeyboardMoverByTile>().enabled = false;
                Objects[i].GetComponent<Catch>().SetCanCatch(false);
            }
            GetComponent<ObjectsSimulate>().enabled = false;
        }
        if(objectsLeft == 0)
        {
            timer.stopTime();
            // Check if coinManager is null before accessing its components
            if (coinManager != null) {
                Debug.Log("the coin manager isnt null");
                coinManager.GetComponent<CoinsManager>().AddNumber(20);
            } else {
                Debug.LogWarning("coinManager is not assigned.");
            }
            winText.SetActive(true); //we want to display a win msg for the player
            /**
            *after trying to run the game without this next line we saw that it just keep on running because of the Update
            *and then the coins just keep growing, so we decide to disable the component when the player win.
            **/
            for(int i=0; i<Objects.Length; i++)
            {
                Objects[i].GetComponent<KeyboardMoverByTile>().enabled = false;
                Objects[i].GetComponent<Catch>().SetCanCatch(false);
            }
            GetComponent<ObjectsSimulate>().enabled = false;
        } 
        if(!currentObject.GetComponent<Catch>().GetCatchingState() && !(currentObjectIndex == Objects.Length))
        { 
            objectsLeft--;
            switchObject();
        }
    }
}