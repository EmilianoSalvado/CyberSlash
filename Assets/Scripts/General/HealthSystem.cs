using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected ParticlesPlayer _particlesPlayer;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip _deathAudioClip;
    [SerializeField] protected AudioClip _damageAudioClip;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void ReceiveDamage(float dmg)
    {
        _currentHealth -= dmg;

        _particlesPlayer.Play();

        if (_currentHealth <= 0)
        { Die(); return; }

        _audioSource.PlayOneShot(_damageAudioClip);
    }

    public void Heal(float h)
    {
        _currentHealth += h;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }

    protected void SetHealth(float a)
    {
        _maxHealth = a;
        _currentHealth = _maxHealth;
    }

    public abstract void Die();
}
