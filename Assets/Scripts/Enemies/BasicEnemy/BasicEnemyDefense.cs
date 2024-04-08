using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyDefense : EnemyDefense
{
    public override void GetAttacked(float dmg)
    {
        _enemyHealth.ReceiveDamage(dmg);
    }
}
