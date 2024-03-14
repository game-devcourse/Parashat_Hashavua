using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    private List<AudioSource> audioSources = new List<AudioSource>();

    private bool isMuted; // Track the mute state

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();

                if (_instance == null)
                {
                    GameObject audioManager = new GameObject("AudioManager");
                    _instance = audioManager.AddComponent<AudioManager>();
                }
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Preserve AudioManager across scene changes
        }
        else
        {
            // Destroy duplicate AudioManager instances
            Destroy(gameObject);
            //return;
        }

        // Get all AudioSources in the scene and add them to the list
        AudioSource[] sourcesInScene = FindObjectsOfType<AudioSource>();
        audioSources.AddRange(sourcesInScene);
    }

    // A method to mute or unmute the music
    public void ManageMusic()
    {
        //we are checking each time the button is pressed what is the state of the misuc and acording to that change the isMuted
        //we don't initialize it at the beggining since every time the audioManager will initialize it will start all over(aka in a new scene)
        if(audioSources[0].volume == 0)
        {
            isMuted = true;
        }
        if(audioSources[0].volume == 1)
        {
            isMuted = false;
        }

        isMuted = !isMuted;
        Debug.Log("start managing music the condition of the music after pressing button is now muted?    " + isMuted);
        // Set the volume based on the mute state
        float volume = isMuted ? 0f : 1f;
        Debug.Log("the number of audioSources:  " + audioSources.Count);
        foreach (var source in audioSources)
        {
            // Check if the AudioSource component is not destroyed
            if (source != null)
            {
                source.volume = volume; // Set the volume
            }
        }
    }
    // Add a method to check if the music is muted
    public bool IsMuted()
    {
        return isMuted;
    }
}
