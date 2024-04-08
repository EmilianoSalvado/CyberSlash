using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator _playerAnimator;

    public void SetAttackTrigger()
    {
        _playerAnimator.SetTrigger("Attack");
    }

    public void SetParryTrigger()
    {
        _playerAnimator.SetTrigger("Defense");
    }

    public void SetRunBool(bool b)
    {
        _playerAnimator.SetBool("Run", b);
    }

    public void SetIdleTrigger()
    {
        _playerAnimator.SetTrigger("Idle");
    }

    public void SetJumpTrigger()
    {
        _playerAnimator.SetTrigger("Jump");
    }

    public void SetDodgeLeftTrigger()
    {
        _playerAnimator.SetTrigger("DodgeLeft");
    }

    public void SetDodgeRightTrigger()
    {
        _playerAnimator.SetTrigger("DodgeRight");
    }
}
