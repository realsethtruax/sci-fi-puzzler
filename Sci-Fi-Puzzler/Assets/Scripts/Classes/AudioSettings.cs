using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioSettings
{
    // Dynamic Settings
    public bool isMuted;
    public float masterVolume;
    public float sfxVolume;
    public float musicVolume;

    public void Initialize() {
        isMuted = false;
        masterVolume = 1.0f;
        sfxVolume = 1.0f;
        musicVolume = 1.0f;
    }
}
