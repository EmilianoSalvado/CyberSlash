using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] int _attacksCount;
    [SerializeField] float _damage;
    [SerializeField] EnemyDefense _enemyDefense;
    [SerializeField] bool _canAttack;

    public bool CanAttack { get { return _canAttack; } }

    public void GetEnemyDefense(EnemyDefense enemyDefense)
    {
        _enemyDefense = enemyDefense;
    }

    public void IncreaseAttacksCount()
    {
        _attacksCount++;
        SetStrings.instance.SetCurrentHits(_attacksCount);
    }

    public void Attack()
    {
        _canAttack = _attacksCount > 0;

        if (_attacksCount <= 0) return;

        _enemyDefense?.GetAttacked(_damage);
        _attacksCount--;
        SetStrings.instance.SetCurrentHits(_attacksCount);
    }
}