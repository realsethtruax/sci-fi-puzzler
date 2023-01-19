using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSystem : Puzzle
{
    [SerializeField] private Switch[] _switches;

    public void UpdateSystem()
    {
        bool isComplete = true;
        foreach (Switch item in _switches)
        {
            if (item.GetSwitchState() == Switch.SwitchState.UNPRESSED) {
                isComplete = false;
            }
        }
        if (isComplete) {
            foreach (var swi in _switches)
            {
                swi.ChangeSwitchState(Switch.SwitchState.SOLVED);
            }
            _isSolved = true;
          //  _solution.Complete();
        }
    }
}
