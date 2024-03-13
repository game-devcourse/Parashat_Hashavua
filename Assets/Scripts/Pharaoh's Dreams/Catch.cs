using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Catch : MonoBehaviour
{
    [SerializeField] string catchTag;
    private bool isCatching = true;
    private bool canCatch = false;
    private bool hasCollided = false; // Flag to track if a collision has occurred

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canCatch && !hasCollided) // Check if catching is enabled and no collision has occurred yet
        {
            if (other.tag == catchTag)
            {
                // Destroy the current object
                Destroy(other.gameObject);

                // After catching the object, disable further catching and collision detection
                isCatching = false;
                hasCollided = true;

                // Disable collider to prevent further collisions
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    // Returning the catching state
    public bool GetCatchingState()
    {
        return isCatching;
    }

    // Setting the can catch option
    public void SetCanCatch(bool change)
    {
        canCatch = change;
    }
}