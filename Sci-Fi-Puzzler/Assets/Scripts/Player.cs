using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    void Update()
    {
        
    }

    public void Grab(InputAction.CallbackContext context) {
        if (context.performed) { 
            Debug.Log("Grab! " + context.phase);
        }
    }
}
