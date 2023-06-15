using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFXEvents : MonoBehaviour
{
    [field: Header("SwitchOn SFX")]
    [field: SerializeField] public EventReference switchToggleOn {get; private set;}

    [field: Header("SwitchOff SFX")]
    [field: SerializeField] public EventReference switchToggleOff {get; private set;}

    [field: Header("SwitchWin SFX")]
    [field: SerializeField] public EventReference switchWin {get; private set;}

    [field: Header("doorOpenSFX")]
    [field: SerializeField] public EventReference doorOpen {get; private set;}

    [field: Header("doorCloseSFX")]
    [field: SerializeField] public EventReference doorClose {get; private set;}

    private void Awake()
    {
        // Singleton implementation
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    public static SFXEvents instance {get; private set;}
}