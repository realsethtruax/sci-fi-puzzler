using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchSystem : Puzzle
{
    [SerializeField] private Switch[] _switches;

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
            // _solution.Complete();
            _openDoor?.Invoke();
            AudioManager.instance.PlayOneShot(FMODEvents.instance.switchWin, this.transform.position);
            Debug.Log("you win");
        }
    }
}
