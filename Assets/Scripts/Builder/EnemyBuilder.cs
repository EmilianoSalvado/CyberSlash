using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder
{
    Enemy _prefab;
    GameObject _playerReference;
    GameObject _playerTrigger;
    Transform _transform;
    IObservable _observableTrigger;

    public EnemyBuilder(Enemy prefab)
    {
        _prefab = prefab;
    }

    public EnemyBuilder SetPosition(Transform t)
    {
        _transform = t;
        return this;
    }

    public EnemyBuilder GetObservableTrigger(GameObject trigger)
    {
        if (trigger.TryGetComponent<IObservable>(out var triggerObservable))
            _observableTrigger = triggerObservable;

        return this;
    }

    public EnemyBuilder GetPlayer(GameObject player)
    {
        _playerReference = player;
        return this;
    }

    public Enemy Done()
    {
        Enemy enemy = GameObject.Instantiate(_prefab, _transform.position, _transform.rotation);
        enemy.GetPlayer(_playerReference);
        enemy.GetObservableTrigger(_observableTrigger);
        return enemy;
    }
}
