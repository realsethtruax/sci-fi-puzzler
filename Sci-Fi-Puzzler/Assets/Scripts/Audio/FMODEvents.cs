using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
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

    

    public static FMODEvents instance {get; private set;}

    private void Awake() 
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events script in the scene.");
        }    
        instance = this;
    }
}
