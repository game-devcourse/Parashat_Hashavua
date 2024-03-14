using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject gameoverText;

    private bool canStart = false;
    private bool OutOfTime = false;

    void Start()
    {
        gameoverText.SetActive(false);
    }

    public void startState()
    {
        canStart = true;
    }

    public void stopTime()
    {
        canStart = false;
    }

    public bool isOutOfTime()
    {
        return OutOfTime;
    }

    void Update()
    {
        if(canStart)
        {
            if(remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                if(remainingTime < 0)
                {
                    remainingTime = 0;
                    OutOfTime = true;
                    timerText.color = Color.red;
                    gameoverText.SetActive(true);
                }
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}