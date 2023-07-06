using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerUIIntegrator : MonoBehaviour
{
    [SerializeField] private Toggle mutedToggle;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        mutedToggle.isOn = AudioManager.audioManagerInstance.GetAudioSettings().isMuted;
        masterSlider.value = AudioManager.audioManagerInstance.GetAudioSettings().masterVolume;
        sfxSlider.value = AudioManager.audioManagerInstance.GetAudioSettings().sfxVolume;
        musicSlider.value = AudioManager.audioManagerInstance.GetAudioSettings().musicVolume;
    }

    public void UpdateMutedToggle()
    {
        AudioManager.audioManagerInstance.ToggleMute(mutedToggle.isOn);
    }

    public void UpdateMasterSlider()
    {
        AudioManager.audioManagerInstance.UpdateMasterAudioLevel(masterSlider.value);
    }

    public void UpdateSFXSlider()
    {
        AudioManager.audioManagerInstance.UpdateSFXAudioLevel(sfxSlider.value);
    }

    public void UpdateMusicSlider()
    {
        AudioManager.audioManagerInstance.UpdateMusicAudioLevel(musicSlider.value);
    }
}
