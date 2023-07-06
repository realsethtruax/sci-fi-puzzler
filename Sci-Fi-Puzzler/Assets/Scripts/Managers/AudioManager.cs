using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Instances
    public static AudioManager audioManagerInstance;

    // FMOD Integrations
    public MusicEvents musicEvents;
    public EventInstance musicInstance;
    private EventReference _music;
    private Bus _masterBus;
    private Bus _musicBus;
    private Bus _sfxBus;

    // Objects for Loading Persistent Data
    private AudioSettings _audioSettings;

    private void Awake()
    {
        // Singleton implementation
        if (audioManagerInstance != null && audioManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        audioManagerInstance = this;
        DontDestroyOnLoad(gameObject);

        // Subscribe to Scene Change Events
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Set Music for Initial Startup
    }

    public void StartUp()
    {
        // Create the Music Event Instance
        //_music = musicEvents.FindMusicForSceneName(SceneManager.GetActiveScene().name);
        //PlayMusic(_music);

        // Set Bus References
        _masterBus = FMODUnity.RuntimeManager.GetBus("bus:/");
        _musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        _sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");

        // Turn On Music
        InitializeMusic();
    }

    public void InitializeMusic()
    {
        ToggleMute(_audioSettings.isMuted);
        _masterBus.setVolume(_audioSettings.masterVolume);
        _sfxBus.setVolume(_audioSettings.sfxVolume);
        _musicBus.setVolume(_audioSettings.musicVolume);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopMusic();
        _music = musicEvents.FindMusicForSceneName(SceneManager.GetActiveScene().name);
        PlayMusic(_music);
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
    
    public void PauseSound()
    {
        if (musicInstance.isValid())
        {
            musicInstance.setPaused(true);
        }
    }

    public void ResumeSound()
    {
        if (musicInstance.isValid())
        {
            musicInstance.setPaused(false);
        }
    }

    public void PlayOneShot(EventReference eventRef)
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventRef);
    }
    public void ToggleMute(bool mutedCheckValue)
    {
        _audioSettings.isMuted = mutedCheckValue;
        _masterBus.setMute(mutedCheckValue);
        _sfxBus.setMute(mutedCheckValue);
        _musicBus.setMute(mutedCheckValue);
    }


    public void UpdateMasterAudioLevel(float newAudioLevel) //Takes a float between 0.0f and 1.0f
    {
        _audioSettings.masterVolume = newAudioLevel;
        _masterBus.setVolume(newAudioLevel);
    }

    public void UpdateSFXAudioLevel(float newAudioLevel) //Takes a float between 0.0f and 1.0f
    {
        _audioSettings.sfxVolume = newAudioLevel;
        _sfxBus.setVolume(newAudioLevel);
    }

    public void UpdateMusicAudioLevel(float newAudioLevel) //Takes a float between 0.0f and 1.0f
    {
        _audioSettings.musicVolume = newAudioLevel;
        _musicBus.setVolume(newAudioLevel);
    }

    public void FetchAudioSettingsFromSaveManager() 
    {
        _audioSettings = SaveManager.saveManagerInstance.GetAudioSettings();
    }

    public void PassCurrentAudioSettingsToSaveManager()
    {
         SaveManager.saveManagerInstance.SetAudioSettings(_audioSettings);
    }

    public AudioSettings GetAudioSettings() {
        if (_audioSettings != null)
        {
            return _audioSettings;
        }
        else {
            return null;
        }
    }
}