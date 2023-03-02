using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationField : MonoBehaviour
{
    // Used to activate objects that make use of the IActivatable interface
    [SerializeField] private GameObject _activatableObject;
    [SerializeField] private bool _deactivateOnExit;

    private Collider2D _trigger;
    private bool _isActive = false;

    private void Awake()
    {
        _trigger = GetComponent<Collider2D>();
        if (_trigger == null) {
            Debug.LogWarning("ActivationField " + this.name + " is not assigned to an activatable object");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Activation Field Entered");
        if (!_isActive && collision.tag == "Player") {
            IActivatable activatible = _activatableObject.GetComponent<IActivatable>();
            if (activatible != null) {
                activatible.Activate();
                _isActive = true;
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Activation Field Exited");
        if (_isActive && _deactivateOnExit && collision.tag == "Player")
        {
            IActivatable activatible = _activatableObject.GetComponent<IActivatable>();
            if (activatible != null)
            {
                _isActive = false;
                activatible.Deactivate();
            }
        }
    }
}
