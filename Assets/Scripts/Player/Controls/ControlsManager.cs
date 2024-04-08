using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public enum PlayerMode { movement, combat}

    [SerializeField] MovementControls _movement;
    [SerializeField] CombatControls _combat;

    public MovementControls Movement { get { return _movement; } }
    public CombatControls Combat { get { return _combat; } }

    public void ChangeControls(PlayerMode playerMode)
    {
        switch (playerMode)
        {
            case PlayerMode.movement:
                _movement.enabled = true;
                _combat.enabled = false;
                break;
            case PlayerMode.combat:
                _movement.enabled = false;
                _combat.enabled = true;
                break;
        }
    }
}
