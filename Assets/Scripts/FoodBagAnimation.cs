using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class FoodBagAnimation : TargetMover//MonoBehaviour
{
    public GameObject Goblet;
    public GameObject[] foodBags;
    public Transform checkPoint;
    public TextMeshProUGUI textDisplay;
    public string sentence;
    public Image scrol;
    public float speed;


    private Vector3 positionBag1, positionBag2, positionBag3;
     protected override void Start()
    {
        positionBag1 = foodBags[1].transform.position;
        positionBag2 = foodBags[2].transform.position;
        positionBag3 = foodBags[3].transform.position;
        tilemapGraph = new TilemapGraph(tilemap, allowedTiles.Get());
        timeBetweenSteps = 1 / speed;
    }

    public void moveBags()
    {
        Debug.Log("the bags are start moving");
        SetTarget(checkPoint.position);
        StartCoroutine(MoveTowardsTheTarget(0));
        SetTarget(positionBag1);
        StartCoroutine(MoveTowardsTheTarget(0));
        SetTarget(checkPoint.position);
        StartCoroutine(MoveTowardsTheTarget(1));
        SetTarget(positionBag2);
        StartCoroutine(MoveTowardsTheTarget(1));
        SetTarget(checkPoint.position);
        StartCoroutine(MoveTowardsTheTarget(2));

        Goblet.SetActive(true);
        scrol.enabled = true; 
        textDisplay.text = sentence;
    }

    IEnumerator MoveTowardsTheTarget(int index) {
        for(;;) {
            yield return new WaitForSeconds(timeBetweenSteps);
            if (enabled && !atTarget)
                MakeOneStepTowardsTheTarget(index);
        }
    }

    protected void MakeOneStepTowardsTheTarget(int index) {
        Vector3Int startNode = tilemap.WorldToCell(foodBags[index].transform.position);
        Vector3Int endNode = targetInGrid;
        List<Vector3Int> shortestPath = BFS.GetPath(tilemapGraph, startNode, endNode, maxIterations);
        if (shortestPath.Count >= 2) { // shortestPath contains both source and target.
            Vector3Int nextNode = shortestPath[1];
            foodBags[index].transform.position = tilemap.GetCellCenterWorld(nextNode);
        } else {
            atTarget = true;
        }
    }
}
