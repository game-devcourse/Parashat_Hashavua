using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] KeyboardMover ob = null;
    [SerializeField] KeyBoardMoverSmoth obS = null;
    [SerializeField] Timer timer;

    void Start()
    {
        if(ob != null) ob.enabled = false;
        if(obS != null) obS.enabled = false;
    }

    //Start is called before the first frame update
    public void CanStart()
    {
        if(timer == null)
        {
            Debug.Log("no timer");
        }
        if(ob != null) ob.enabled = true;
        if(obS != null) obS.enabled = true;
    }

    public void StopGame()
    {
        if(timer.isOutOfTime())
        {
            if(ob != null) ob.enabled = false;
            if(obS != null) obS.enabled = false;
        }
    }

    void Update()
    {
        StopGame();
    }
}