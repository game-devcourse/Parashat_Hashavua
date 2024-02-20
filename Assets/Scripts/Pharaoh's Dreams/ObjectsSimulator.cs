using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsSimulate : MonoBehaviour
{
    [SerializeField] GameObject[] Objects; // Array to hold the object
    [SerializeField] string sceneName; //the scene we want to move to once the player wins the game(aka catches all the objects)

    private int currentObjectIndex = 0; // Index to track the current object
    private GameObject currentObject;
    private int objectsLeft;

    private void Start()
    {
        objectsLeft = Objects.Length;
        currentObject = Objects[currentObjectIndex]; //Instantiate(Objects[currentObjectIndex], transform.position, Quaternion.identity);
        currentObject.GetComponent<KeyboardMoverByTile>().enabled = true;
        currentObject.GetComponent<Catch>().SetCanCatch(true);
        for(int i=1; i<Objects.Length; i++)
        {
            Objects[i].GetComponent<KeyboardMoverByTile>().enabled = false;
            Objects[i].GetComponent<Catch>().SetCanCatch(false);
        }
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
        if(objectsLeft == 0)
        {
            SceneManager.LoadScene(sceneName);
        } 
        if(!currentObject.GetComponent<Catch>().GetCatchingState() && !(currentObjectIndex == Objects.Length))
        { 
            objectsLeft--;
            switchObject();
        }
    }
}
