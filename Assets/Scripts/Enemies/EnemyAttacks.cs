using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] EnemyAnimations _animations;

    [SerializeField] PlayerDefense _playerDefense;

    [SerializeField] int _attackCount;
    [SerializeField] float _timeBetweenAttacks;
    [SerializeField] float _coolDown;
    [SerializeField] float _damage;

    public void StartAttackCoroutine()
    {
        if (_animations.MustStop) return;
        StartCoroutine("AttackCoroutine");
    }

    IEnumerator AttackCoroutine()
    {
        var wait = new WaitForSeconds(_timeBetweenAttacks);

        yield return new WaitForSeconds(_coolDown);

        for (int i = 0; i < _attackCount; i++)
        {
            _animations.Attack();

            yield return wait;
        }

        StartAttackCoroutine();
    }

    public void ParryAttack(PlayerDefense.PlayerParry parry)
    {
        _playerDefense.GetParryAttack(parry, _damage);
    }

    public void DodgeAttack(PlayerDefense.PlayerDodge dodge)
    {
        _playerDefense.GetDodgeAttack(dodge, _damage);
    }

    public void GetPlayer(PlayerDefense pd)
    {
        _playerDefense = pd;
    }
}
