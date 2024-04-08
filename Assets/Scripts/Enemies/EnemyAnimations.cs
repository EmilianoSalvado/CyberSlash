using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] Animator _animator;

    bool _mustStop = false;
    public bool MustStop {  get { return _mustStop; } }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    public void Damaged()
    {
        _animator.SetTrigger("Damaged");
    }

    public void Die()
    {
        if (TryGetComponent<Collider>(out var collider))
            collider.enabled = false;
        _mustStop = true;
        _animator.SetTrigger("Die");
    }
}
