using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemy : MonoBehaviour
{
    [SerializeField] PlayerAttacks _playerAttacks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SetPlayerInPlace>(out var trigger))
        {
            if (trigger.EnemyAttached != null && trigger.EnemyAttached.TryGetComponent<EnemyDefense>(out var enemyDefense))
                _playerAttacks.GetEnemyDefense(enemyDefense);
        }
    }
}
