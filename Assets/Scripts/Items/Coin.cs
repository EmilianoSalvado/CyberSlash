using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;

    [SerializeField] float _speed;
    [SerializeField] float _rotationSpeed;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerActions>().transform;
    }

    private void Update()
    {
        transform.position += ((_playerTransform.position + _playerTransform.up * 1.5f) - transform.position).normalized * (_speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
    }

    public static void TurnOn(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }

    public static void TurnOff(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }
}
