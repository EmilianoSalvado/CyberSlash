using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFactory : MonoBehaviour
{
    [SerializeField] Coin _coinPrefab;
    [SerializeField] int _poolCoinsAmount;

    ObjectPool<Coin> _pool;

    public static CoinFactory Instance { get; private set; }

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(CoinMaker, Coin.TurnOn, Coin.TurnOff, _poolCoinsAmount);
        Instance = this;
    }

    Coin CoinMaker()
    {
        return Instantiate(_coinPrefab);
    }

    public Coin GetCoin()
    {
        return _pool.GetObject();
    }

    public void ReturnCoin(Coin coin)
    {
        _pool.ReturnObject(coin);
    }
}
