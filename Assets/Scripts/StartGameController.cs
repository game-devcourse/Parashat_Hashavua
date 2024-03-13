using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    [SerializeField] KeyboardMover ob = null;
    [SerializeField] KeyBoardMoverSmoth obS = null;

    void Start()
    {
        if(ob != null) ob.enabled = false;
        if(obS != null) obS.enabled = false;
    }

    //Start is called before the first frame update
    public void CanStart()
    {
        if(ob != null) ob.enabled = true;
        if(obS != null) obS.enabled = true;
    }
}