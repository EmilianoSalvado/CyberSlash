using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    [SerializeField] EnemyAnimations _enemyAnimations;
    [SerializeField] ControlsManager _controlsManager;
    [SerializeField] int _coinAmount;
    [SerializeField] float _timeBetweenCoinDrop;

    public override void ReceiveDamage(float dmg)
    {
        base.ReceiveDamage(dmg);

        _enemyAnimations.Damaged();
    }

    public override void Die()
    {
        var enemy = GetComponent<Enemy>();
        if (Physics.Raycast(transform.position, - transform.forward, out var hit, enemy.SpawnerLayer))
        {
            if (hit.collider.GetComponent<Spawner>())
            {
                var spawner = hit.collider.GetComponent<Spawner>();
                var t = hit.collider.GetComponent<Transform>();
                hit.collider.enabled = false;
                var trigger = spawner.Trigger;

                enemy.Clone(spawner, t, trigger);
            }
        }

        _audioSource.PlayOneShot(_deathAudioClip);
        _enemyAnimations.Die();
        StartCoroutine("DropCoins");
        _controlsManager.ChangeControls(ControlsManager.PlayerMode.movement);
    }

    IEnumerator DropCoins()
    {
        var waitTime = new WaitForSeconds(_timeBetweenCoinDrop);

        for (int i = 0; i < _coinAmount; i++)
        {
            yield return waitTime;

            var coin = CoinFactory.Instance.GetCoin();
            coin.transform.position = transform.position + transform.up;
        }
    }

    public void GetPlayer(ControlsManager cm)
    {
        _controlsManager = cm;
    }
}