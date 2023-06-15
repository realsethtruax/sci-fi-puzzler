using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public enum SwitchState { LOCKED, PRESSED, UNPRESSED, SOLVED }

    [SerializeField] private SwitchSystem switchSystem;
    [SerializeField] private SwitchState _state = SwitchState.UNPRESSED;

    [SerializeField] private bool _staysPressed; // If the switch will remain pressed after the player exits the trigger volume
    [SerializeField] private bool _canBeTurnedOff; // If re-entering the trigger volume will turn off the switch
    [SerializeField] private bool _isLocked; // Prevents the Switch From Being Toggled

    [SerializeField] private Sprite _pressedSprite;
    [SerializeField] private Sprite _unpressedSprite;
    [SerializeField] private Sprite _solvedSprite;
    [SerializeField] private Sprite _lockedSprite;


    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;


    void Start()
    {
        // Setup Collider
        _collider2D = GetComponent<Collider2D>();

        // Ensure Switch belongs to switch system
        if (this.switchSystem == null)
        {
            Debug.LogError(this.gameObject.name + " doesn't belong to a SwitchSystem object.");
        }

        // Setup Sprite Renderer and Default Sprite
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        if (this.GetSwitchState() == SwitchState.PRESSED)
        {
            _spriteRenderer.sprite = _pressedSprite;
        }
        else if (this.GetSwitchState() == SwitchState.UNPRESSED)
        {
            _spriteRenderer.sprite = _unpressedSprite;
        }
        else if (this.GetSwitchState() == SwitchState.LOCKED)
        {
            _spriteRenderer.sprite = _unpressedSprite;
        }
        else
        {
            _spriteRenderer.sprite = _solvedSprite;
        }
    }

    public SwitchState GetSwitchState()
    {
        return _state;
    }

    public void ChangeSwitchState(SwitchState state)
    {
        _state = state;
        switch (state)
        {
            case SwitchState.LOCKED:
                switchSystem.UpdateSystem();
                break;
            case SwitchState.PRESSED:
                _spriteRenderer.sprite = _pressedSprite;
                switchSystem.UpdateSystem();
                AudioManager.instance.PlayOneShot(SFXEvents.instance.switchToggleOn);
                break;
            case SwitchState.UNPRESSED:
                _spriteRenderer.sprite = _unpressedSprite;
                switchSystem.UpdateSystem();
                AudioManager.instance.PlayOneShot(SFXEvents.instance.switchToggleOff);
                break;
            case SwitchState.SOLVED:
                _spriteRenderer.sprite = _solvedSprite;
                _state = SwitchState.SOLVED;
                _collider2D.enabled = false;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_state != SwitchState.LOCKED)
        {
            if (_state == SwitchState.PRESSED)
            {
                if (_canBeTurnedOff)
                {
                    this.ChangeSwitchState(SwitchState.UNPRESSED);

                }
            }
            else if (_state == SwitchState.UNPRESSED)
            {
                this.ChangeSwitchState(SwitchState.PRESSED);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_staysPressed && _state != SwitchState.SOLVED && _state != SwitchState.LOCKED)
        {
            this.ChangeSwitchState(SwitchState.UNPRESSED);
        }
    }

    public void LockSwitch()
    {
        _state = SwitchState.LOCKED;
    }
    public void UnlockSwitch()
    {
        _state = SwitchState.UNPRESSED;
    }
}
