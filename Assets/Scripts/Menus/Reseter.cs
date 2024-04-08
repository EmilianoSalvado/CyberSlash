using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{
    [SerializeField] GameObject[] _toReset;
    [SerializeField] List<bool> _reseterBools;

    private void Start()
    {
        for (int i = 0; i < _toReset.Length; i++)
        {
            if (_toReset[i].activeSelf)
                _reseterBools.Add(true);
            else
                _reseterBools.Add(false);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _toReset.Length; i++)
        {
            _toReset[i].SetActive(_reseterBools[i]);
        }
    }
}
