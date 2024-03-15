using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    [SerializeField] GameObject startGameText;
    [SerializeField] Timer timer;
    [SerializeField] GameController controllerGame = null;
    [SerializeField] AudioManager music;
   
    /**
        This script is responsible to manage all actions that should happen in a button presss,
        it contains different actions so in every scne we can use the same script. 
        This script is attached to a manager for a button component.
    */

    //A method that responsible to start a new scene
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //A method thet responsible to manage the starting of a game- disable the start window, start the timer etc.
    public void startGame()
    {
        startGameText.SetActive(false);
        controllerGame.CanStart();
        timer.startState();
    }

    //A method that responsible for the mute an unmute option of an audio
    public void ManageMusic()
    {
        // Call the AudioManager's ManageMusic method
        music.ManageMusic();
    }
}