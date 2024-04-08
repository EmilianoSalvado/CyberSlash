using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IObserver
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] GameObject _playerReference;
    public GameObject PlayerReference { get { return _playerReference; } }
    [SerializeField] GameObject _trigger;
    public GameObject Trigger { get { return _trigger; } }

    public void Notify(string action)
    {
        var enemy = new EnemyBuilder(_enemyPrefab).GetPlayer(_playerReference).SetPosition(transform).GetObservableTrigger(_trigger).Done();
        SetPlayerEnemyRefernce(enemy);
    }

    public void SetPlayerEnemyRefernce(Enemy enemy)
    {
        _playerReference.GetComponent<PlayerAttacks>().GetEnemyDefense(enemy.GetComponent<EnemyDefense>());
    }
}
