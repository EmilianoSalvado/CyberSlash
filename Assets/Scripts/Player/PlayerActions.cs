using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] PlayerDefense _playerDefense;
    [SerializeField] PlayerAttacks _playerAttacks;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] PlayerAnimations _playerAnimations;

    [Header("Movement")]
    [SerializeField] bool _canRun;
    [SerializeField] LayerMask _platformLayer;

    public void Run()
    {
        if (!_canRun) return;
        
        _playerMovement.Run();
        _playerAnimations.SetRunBool(true);
    }

    public void Jump(Vector3 vector)
    {
        if (_canRun || !Physics.Raycast(transform.position, -transform.up, 1.3f)) return;

        Ray screenRay = Camera.main.ScreenPointToRay(Input.touches[0].position);
        RaycastHit hit;

        _playerAnimations.SetJumpTrigger();

        if (Physics.Raycast(screenRay, out hit, 99999, _platformLayer))
        {
            Vector3 v = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
            _playerMovement.SetInPlace(v);
            return;
        }
    }

    public void Stop()
    {
        _playerAnimations.SetRunBool(false);
        _playerMovement.Stop();
    }

    public void Defense(Vector3 vector)
    {
        float angle = (Vector3.Angle(Vector3.right, vector));

        if (angle < 20 && angle > -10)
        {
            _playerDefense.SetCurrentDodge(PlayerDefense.PlayerDodge.Right);
            _playerAnimations.SetDodgeRightTrigger();
        }
        else if (angle > 160 && angle < 200)
        {
            _playerDefense.SetCurrentDodge(PlayerDefense.PlayerDodge.Left);
            _playerAnimations.SetDodgeLeftTrigger();
        }
        else if (angle > 70 && angle < 110 && vector.y > 0)
        {
            _playerDefense.SetCurrentDodge(PlayerDefense.PlayerDodge.Jump);
            _playerAnimations.SetJumpTrigger();
        }

        else if (angle > 90)
        {
            if (vector.y > 0)
                _playerDefense.SetCurrentParry(PlayerDefense.PlayerParry.UpLeft);
            else
                _playerDefense.SetCurrentParry(PlayerDefense.PlayerParry.DownLeft);

            _playerAnimations.SetParryTrigger();
            return;
        }
        else if (angle < 90)
        {
            if (vector.y > 0)
                _playerDefense.SetCurrentParry(PlayerDefense.PlayerParry.UpRight);
            else
                _playerDefense.SetCurrentParry(PlayerDefense.PlayerParry.DownRight);

            _playerAnimations.SetParryTrigger();
            return;
        }
    }

    public void Attack()
    {
        _playerAttacks.Attack();

        if (_playerAttacks.CanAttack)
            _playerAnimations.SetAttackTrigger();
    }

    public void SetCanRun(bool b)
    {
        _canRun = b;
    }
}
