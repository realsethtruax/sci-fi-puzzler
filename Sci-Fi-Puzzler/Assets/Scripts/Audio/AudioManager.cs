using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private void Awake()
    // setting up Singleton class functionality for Audio Manager
    {
        // First, check to see if another instance of the audio manager exists, and log an error if there is one
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        // If there isn't one, set the instance to this audio manager
        instance = this;
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
