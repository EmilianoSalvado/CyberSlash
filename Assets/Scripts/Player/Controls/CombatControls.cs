using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatControls : Controls
{
    protected override void TouchAction()
    {
        _playerActions.Attack();
    }

    protected override void SwipeAction(Vector3 swipeDir)
    {
        _playerActions.Defense(swipeDir);
    }
}
