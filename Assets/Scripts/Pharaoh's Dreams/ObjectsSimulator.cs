using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSimulate : MonoBehaviour
{
    [SerializeField] GameObject[] Objects; // Array to hold the object
    private int currentObjectIndex = 0; // Index to track the current object
    private GameObject currentObject;

    private void Start()
    {
        currentObject = Objects[currentObjectIndex]; //Instantiate(Objects[currentObjectIndex], transform.position, Quaternion.identity);
        currentObject.GetComponent<KeyboardMoverByTile>().enabled = true;
        currentObject.GetComponent<Catch>().setCanCatch(true);
        for(int i=1; i<Objects.Length; i++)
        {
            Objects[i].GetComponent<KeyboardMoverByTile>().enabled = false;
            Objects[i].GetComponent<Catch>().setCanCatch(false);
        }
    }

    private void switchObject()
    {
        //disabling the previous cow
        Objects[currentObjectIndex].GetComponent<Catch>().setCanCatch(false);
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
            currentObject.GetComponent<Catch>().setCanCatch(true);
        }
        else
        {
            Debug.Log("All objects collected!");
            // You can add your logic here for what should happen after all objects are collected
        }
    }

    void Update()
    {
        if(!currentObject.GetComponent<Catch>().getCatchingState()) switchObject();
    }
}
