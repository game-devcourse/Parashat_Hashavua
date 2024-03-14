using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MouseClick : MonoBehaviour
{
    [SerializeField] GameObject startGameText;
    [SerializeField] Timer timer;
    [SerializeField] GameController controllerGame = null;
    [SerializeField] AudioManager music;
   
    /**
        This script is responsible to load a scene that will be giving in the unity, 
        this script is attached to a manager for a button component.
    */
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void startGame()
    {
        startGameText.SetActive(false);
        controllerGame.CanStart();
        timer.startState();
    }

    public void ManageMusic()
    {
        music.ManageMusic();
    }
}