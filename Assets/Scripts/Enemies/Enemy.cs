using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObserver, IPrototype
{
    [SerializeField] EnemyAttacks _attacks;
    [SerializeField] EnemyDefense _enemyDefense;
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] EnemyAttacks _attacksScript;

    [SerializeField] IObservable _playerCombatTrigger;

    delegate void Method();
    Method _attackMethod;

    Dictionary<string, Method> _methodsDictionary;

    [SerializeField] LayerMask _spawnerLayer;
    public LayerMask SpawnerLayer { get { return _spawnerLayer; } }

    private void Start()
    {
        _attackMethod = StartAttacking;
        _methodsDictionary = new Dictionary<string, Method>();
        _methodsDictionary.Add("Attack", _attackMethod);
    }

    public void GetPlayer(GameObject player)
    {
        if (player.TryGetComponent<PlayerDefense>(out var pd))
            _attacksScript.GetPlayer(pd);

        if (player.TryGetComponent<ControlsManager>(out var cm))
            _enemyHealth.GetPlayer(cm);
    }

    public void GetObservableTrigger(IObservable io)
    {
        _playerCombatTrigger = io;
        _playerCombatTrigger.Subscribe(this);
    }

    void StartAttacking()
    {
        _attacks.StartAttackCoroutine();
    }

    public void Notify(string action)
    {
        if (_methodsDictionary.ContainsKey(action))
            _methodsDictionary[action].Invoke();
    }

    public void Clone(Spawner spawner, Transform t, GameObject trigger)
    {
        var enemy = new EnemyBuilder(this).GetPlayer(spawner.PlayerReference).GetObservableTrigger(trigger).SetPosition(t).Done();

        var pr = spawner.PlayerReference;
        pr.GetComponent<PlayerAttacks>().GetEnemyDefense(enemy.GetComponent<EnemyDefense>());
    }
}