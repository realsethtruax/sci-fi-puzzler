using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
    // States
    private bool _isInitialized = false;

    // Locks
    private bool _audioSettingsLocked = true;

    // This class is used to save and unload persistent data from hardware into the game
    public static SaveManager saveManagerInstance;

    // Classes for Persistent Data
    private AudioSettings _audioSettings;
    // private PlayerSaveDetails _playerSaveDetails;
    // private LevelProgress _levelProgress;

    // Objects for Loading Persistent Data
    private FileStream _dataStream;
    private BinaryFormatter _converter = new BinaryFormatter();

    // FilePaths
    private string _audioSettingsFilePath;

    private void Awake()
    {
        // Implement Singleton Pattern and Setup Instance
        if (saveManagerInstance != null && saveManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        saveManagerInstance = this;
        DontDestroyOnLoad(gameObject);

        // Load Game-Critical Persistent Data
        // Load AudioSettings Class
        _audioSettingsFilePath = Application.persistentDataPath + "/audioData.data";
        Debug.Log(_audioSettingsFilePath);
        OpenOrCreatePersistentAudioSettingsFile(_audioSettingsFilePath);

        // Unlock Resources
        _audioSettingsLocked = false;

        // Update states for external files
        _isInitialized = true;
    }

    // Audio Setings Persistent Data Methods
    private void OpenOrCreatePersistentAudioSettingsFile(string filepath) {
        _audioSettings = new AudioSettings();
        _audioSettings.Initialize();
        _dataStream = new FileStream(filepath, FileMode.OpenOrCreate);
        _audioSettings = _converter.Deserialize(_dataStream) as AudioSettings;
        _dataStream.Close();
        Debug.Log("AudioSettings class loaded into SaveManager");
    }

    private void UpdatePersistentAudioSettingsFile(string filepath) {
        _dataStream = new FileStream(filepath, FileMode.Open);
        _converter.Serialize(_dataStream, _audioSettings);
        _dataStream.Close();
        Debug.Log("SaveManager AudioSettings class dumped to file");
    }

    public bool GetInitialized() {
        return _isInitialized;
    }

    public AudioSettings GetAudioSettings() {
        if (_audioSettingsLocked) {
            Debug.LogError("A class is trying to access the audio settings, but the _audioSettingsLock is enabled. Only one class can update the data at a time");
            return null;
        } else {
            _audioSettingsLocked = true;
            return _audioSettings;
        }
    }

    public void SetAudioSettings(AudioSettings updatedSettings)
    {
        if (_audioSettingsLocked)
        {
            _audioSettings = updatedSettings;
            UpdatePersistentAudioSettingsFile(_audioSettingsFilePath);
            _audioSettingsLocked = false;
        }
        else
        {
            Debug.LogError("A class is trying to update the audio settings, but the _audioSettingsLock is disabled, which could cause data issues. \nData must be pulled from the save manager by only one class at a time.");
        }
    }
}
