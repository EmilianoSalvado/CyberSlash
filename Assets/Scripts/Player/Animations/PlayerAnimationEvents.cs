using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] PlayerDefense _playerDefense;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] ControlsManager _controlsManager;

    public void ClearDefense()
    {
        _playerDefense.Clear();
    }

    public void Jump()
    {
        if (!_controlsManager.Movement.enabled)
            return;

        _playerMovement.Jump();
    }
}