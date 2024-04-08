using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _buildings;
    [SerializeField] float _time;
    float _count;

    private void Update()
    {
        _count += Time.deltaTime;

        if (_count > _time)
        {
            Instantiate
                (_buildings[Random.Range(0, _buildings.Length)], transform.position + new Vector3(0, 0, Random.Range(-3f, 3f)), transform.rotation);
            _count = 0;
        }
    }
}
