using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private float _masterVolume;
    [SerializeField] private float _sfxVolume;
    [SerializeField] private float _soundtrackVolume;

    [SerializeField] private AudioSource __sfxSource;
    [SerializeField] private AudioSource __soundtrackSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void PlaySFX(AudioClip clip) {
        __sfxSource.PlayOneShot(clip); 
    }
}
