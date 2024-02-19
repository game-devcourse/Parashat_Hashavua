using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//This Script is responsible to the moving around randomaly of an object, it takes the patroller script from class with a little change
public class Wandering : TargetMover
{
    [SerializeField] Cycle patrolPath = null;
    [SerializeField] GameObject[] cowsObjects; // Array to hold the cows

    [SerializeField] private int pointCount;
    [SerializeField] private int currentPointIndex;

    protected override void Start()  {
        base.Start();
        pointCount = patrolPath.transform.childCount;
    }

    private void Update() {
        if (atTarget) {
            currentPointIndex = (Random.Range(0, pointCount) + 1) % pointCount;
        }
        SetTarget(patrolPath.transform.GetChild(currentPointIndex).position);
    }
}