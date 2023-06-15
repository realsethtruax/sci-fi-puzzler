using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;
  
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public MusicEvents musicEvents;
    EventInstance musicInstance;
    private EventReference music;
    private bool isPaused;
    private void Awake()
    {
        // Singleton implementation
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        StopMusic();
        music = musicEvents.FindMusicForSceneName(SceneManager.GetActiveScene().name);
        PlayMusic(music);
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        StopMusic();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopMusic();
        music = musicEvents.FindMusicForSceneName(SceneManager.GetActiveScene().name);
        PlayMusic(music);
    }
    public void PlayMusic(EventReference sceneMusic)
    {
        if (sceneMusic.IsNull)
        {
            musicInstance = RuntimeManager.CreateInstance(musicEvents.None);
            musicInstance.start();
        }
        else
        {
            musicInstance = RuntimeManager.CreateInstance(sceneMusic);
            musicInstance.start();
        }

    }
    public void StopMusic()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicInstance.release();
        }
    }
    
    //Not Yet Implemented
    public void PauseMusic()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            isPaused = true;
        }
    }

    //Not Yet Implemented
    public void ResumeMusic()
    {
        if (isPaused)
        {
            musicInstance.start();
        }
    }

    // Play a one-shot sound effect using an event reference
    public void PlayOneShot(EventReference eventRef)
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventRef);
    }
}