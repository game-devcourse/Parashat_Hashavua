using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] KeyboardMover ob = null;
    [SerializeField] Timer timer;

    void Start()
    {
        if(ob != null) ob.enabled = false;
    }

    //Start is called before the first frame update
    public void CanStart()
    {
        if(ob != null) ob.enabled = true;
    }

    public void StopGame()
    {
        if(timer.isOutOfTime())
        {
            if(ob != null) ob.enabled = false;
        }
    }

    void Update()
    {
        StopGame();
    }
}