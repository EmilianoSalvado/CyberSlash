using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>
{
    Func<T> _factoryMethod;
    List<T> _stock;

    Action<T> _turnOn;
    Action<T> _turnOff;

    public ObjectPool(Func<T> factoryMethod, Action<T> turnOn, Action<T> turnOff, int amount)
    {
        _factoryMethod = factoryMethod;
        _stock = new List<T>();
        _turnOn = turnOn;
        _turnOff = turnOff;

        for (int i = 0; i < amount; i++)
        {
            T obj = _factoryMethod();

            _turnOff(obj);

            _stock.Add(obj);
        }
    }

    public T GetObject()
    {
        var result = default(T);

        if (_stock.Count > 0)
        {
            result = _stock[0];
            _stock.RemoveAt(0);
        }
        else
            result = _factoryMethod();

        _turnOn(result);

        return result;
    }

    public void ReturnObject(T obj)
    {
        _turnOff(obj);
        _stock.Add(obj);
    }
}
