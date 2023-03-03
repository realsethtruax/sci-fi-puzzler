using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour, IActivatable
{
    [SerializeField] private bool _isOn = true;
    [SerializeField] private SpriteRenderer fanSpriteRend;
    [SerializeField] private int maxFanSpeed = 1000;
    [SerializeField] private int currentFanSpeed = 0;
    [SerializeField] private int fanAccelRate = 5;

    void Awake() {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers)
        {
            if (renderer.name == "Blade")
            {
                fanSpriteRend = renderer;
            }
        }
    }
    private void Update()
    {
        if (_isOn) {
            if (currentFanSpeed < maxFanSpeed)
            {
                currentFanSpeed += fanAccelRate;
            }
            else {
                currentFanSpeed = maxFanSpeed;
            }
        }
        else {
            if (currentFanSpeed > 0)
            {
                currentFanSpeed -= fanAccelRate;
            }
            else {
                currentFanSpeed = 0;
            }
        }
        fanSpriteRend.gameObject.transform.Rotate(new Vector3(0, 0, -currentFanSpeed * Time.deltaTime)); 
    }

    public void Activate()
    {
        _isOn = true;
    }

    public void Deactivate()
    {
        _isOn = false;
    }
}
