using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


//This method was taken from https://www.youtube.com/watch?v=yFKg8qVclBk
public class PickUpAndDrop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dropText;
    [SerializeField] private TextMeshProUGUI pickUpText;
    [SerializeField] private string pickUpTag;
    [SerializeField] private string dropTag;
    [SerializeField] private GameObject itemToDrop;
    [SerializeField] GameObject coinManager;
    [SerializeField] GameObject winScreen;
    [SerializeField] private Timer timer;
    [SerializeField] private int orderInlayerAfterPickUp;
    [SerializeField] private int orderInlayerAfterDrop;

    private bool pickUpAllowed;
    private bool dropAllowed;


	// Use this for initialization
	private void Start () {
        pickUpText.gameObject.SetActive(false);
        dropText.gameObject.SetActive(false);
        winScreen.SetActive(false);
	}
	
	// Update is called once per frame
	private void Update () {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
        if (dropAllowed && Input.GetKeyDown(KeyCode.E))
            Drop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == pickUpTag)
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }   
        if (other.tag == dropTag)
        {
            dropText.gameObject.SetActive(true);
            dropAllowed = true;
        }          
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == pickUpTag)
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
        if (other.tag == dropTag)
        {
            dropText.gameObject.SetActive(false);
            dropAllowed = false;
        }
    }

    private void PickUp()
    {
        itemToDrop.transform.SetParent(transform);
        itemToDrop.GetComponent<SpriteRenderer>().sortingOrder = orderInlayerAfterPickUp;
        itemToDrop.GetComponent<Collider2D>().enabled = false;
    }

    private void Drop()
    {
        GameObject dropObject = GameObject.FindWithTag(dropTag);

        // Check if the GameObject was found
        if (dropObject != null)
        {
            itemToDrop.transform.SetParent(dropObject.transform);
            timer.stopTime();
            GetComponent<KeyboardMover>().enabled = false;
            itemToDrop.GetComponent<SpriteRenderer>().sortingOrder = orderInlayerAfterDrop;
            dropText.gameObject.SetActive(false);
            pickUpText.gameObject.SetActive(false);
            winScreen.SetActive(true);
            if (coinManager != null) {
                Debug.Log("the coin manager isnt null");
                coinManager.GetComponent<CoinsManager>().AddNumber(20);
            } else {
                Debug.LogWarning("coinManager is not assigned.");
            }
        }
        else
        {
            Debug.LogWarning("No object found with tag: " + dropTag + "or with tag: " + pickUpTag);
        }

    }
}
