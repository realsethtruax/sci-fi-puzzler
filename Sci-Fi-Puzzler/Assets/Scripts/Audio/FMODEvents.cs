using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("SwitchOn SFX")]
    [field: SerializeField] public EventReference switchToggleOn {get; private set;}

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
