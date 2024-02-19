using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Catch : MonoBehaviour
{
    [SerializeField] string catchTag;
    private bool isCatching = true;
    private bool canCatch = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(canCatch)
        {
            if (other.tag == catchTag)
            {
                // Destroy the current object
                Destroy(other.gameObject);

                //after catching the object disable the catching state
                isCatching = false;
            }
        }
    }

    //returning the catching state
    public bool getCatchingState()
    {
        return isCatching;
    }

    //setting the can catch option
    public void setCanCatch(bool change)
    {
        canCatch = change;
    }
}
