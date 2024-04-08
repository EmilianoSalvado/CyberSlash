using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : Controls
{
    protected override void TouchAction()
    {
        _playerActions.Run();
    }

    protected override void SwipeAction(Vector3 swipeDir)
    {
        _playerActions.Jump(swipeDir);
    }
}
