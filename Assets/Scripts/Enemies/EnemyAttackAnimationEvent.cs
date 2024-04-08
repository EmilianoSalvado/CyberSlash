using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnimationEvent : MonoBehaviour
{
    [SerializeField] EnemyAttacks _enemyAttacks;

    public void AttackUpRight()
    {
        _enemyAttacks.ParryAttack(PlayerDefense.PlayerParry.UpRight);
    }

    public void AttackUpLeft()
    {
        _enemyAttacks.ParryAttack(PlayerDefense.PlayerParry.UpLeft);
    }

    public void AttackRight()
    {
        _enemyAttacks.DodgeAttack(PlayerDefense.PlayerDodge.Right);
    }

    public void AttackLeft()
    {
        _enemyAttacks.DodgeAttack(PlayerDefense.PlayerDodge.Left);
    }

    public void AttackUp()
    {
        _enemyAttacks.DodgeAttack(PlayerDefense.PlayerDodge.Jump);
    }
}
