using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _musicIntro;

    void Start()
    {
        AudioManager.Instance.PlayLoopingSoundtrack(_musicIntro);
    }
}
