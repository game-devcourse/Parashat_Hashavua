using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    private List<AudioSource> audioSources = new List<AudioSource>();

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
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Get all AudioSources in the scene and add them to the list
        AudioSource[] sourcesInScene = FindObjectsOfType<AudioSource>();
        audioSources.AddRange(sourcesInScene);
    }

    // Add a method to play the music on all AudioSources
    public void PlayMusicOnAllSources()
    {
        foreach (var source in audioSources)
        {
            source.Play();
        }
    }
}
