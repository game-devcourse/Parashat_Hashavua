using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    [SerializeField] KeyboardMover ob;

    void Start()
    {
        ob.enabled = false;
    }

    //Start is called before the first frame update
    public void CanStart()
    {
        ob.enabled = true;
    }
}
