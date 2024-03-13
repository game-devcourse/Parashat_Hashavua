using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{   
    [SerializeField] GameObject coinManager;
    
    void Start()
    {
        coinManager.GetComponent<CoinsManager>().SetNumber();
    }
}
