using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOnTrigger : MonoBehaviour
{
   [SerializeField] string triggerTag;
   [SerializeField] GameObject targetObject;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggerTag) {
            targetObject.GetComponent<StartTalking>().enabled = true;
            targetObject.GetComponent<StartTalking>().Enable();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == triggerTag) {
            targetObject.GetComponent<StartTalking>().enabled = false;
            targetObject.GetComponent<StartTalking>().Disable();
        }
    }
}