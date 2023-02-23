using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchSystem : Puzzle
{
    [SerializeField] private Switch[] _switches;

    [SerializeField] private AudioClip _WinSound;
    public UnityEvent _openDoor;

    public void UpdateSystem()
    {
        bool isComplete = true;
        foreach (Switch item in _switches)
        {
            if (item.GetSwitchState() == Switch.SwitchState.UNPRESSED)
            {
                isComplete = false;
            }
        }
        if (isComplete)
        {
            foreach (var swi in _switches)
            {
                swi.ChangeSwitchState(Switch.SwitchState.SOLVED);
            }
            _isSolved = true;
            StartCoroutine(PlayWinSound());
            // _solution.Complete();
            _openDoor?.Invoke();
            Debug.Log("you win");
        }
    }
    IEnumerator PlayWinSound(){
        AudioManager.Instance.PlaySFX(_WinSound);
        yield return new WaitForSeconds(.8f);
    }
}
