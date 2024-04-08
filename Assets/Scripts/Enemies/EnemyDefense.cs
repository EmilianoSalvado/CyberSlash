using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDefense : MonoBehaviour
{
    [SerializeField] protected HealthSystem _enemyHealth;

    public abstract void GetAttacked(float dmg);
}
