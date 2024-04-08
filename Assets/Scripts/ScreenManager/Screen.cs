using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : IScreen
{
    Dictionary<Behaviour, bool> _behavioursBools = new Dictionary<Behaviour, bool>();

    Transform _root;

    public Screen (Transform root)
    {
        _root = root;

        foreach (var behaviour in _root.GetComponentsInChildren<Behaviour>())
        {
            _behavioursBools.Add(behaviour,behaviour.enabled);
        }
    }

    public void Activate()
    {
        foreach (var behaviour in _behavioursBools.Keys)
        {
            behaviour.enabled = _behavioursBools[behaviour];
        }
        _behavioursBools.Clear();

        _root.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        foreach (var behaviour in _root.GetComponentsInChildren<Behaviour>())
        {
            _behavioursBools[behaviour] =  behaviour.enabled;
            behaviour.enabled = false;
        }

        _root.gameObject.SetActive(false);
    }
}
