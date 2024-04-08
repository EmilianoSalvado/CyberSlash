using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB : MonoBehaviour
{
    [SerializeField] Material[] _materials;
    [SerializeField] float _speed;
    Color _color = new Color(1,0,0,1);

    private void Update()
    {
        if (_color.r >= 1 && _color.g < 1 && _color.b <= 0)
        {
            _color.g += _speed * Time.deltaTime;
        }
        else if (_color.r > 0 && _color.g >= 1 && _color.b <= 0)
        {
            _color.r -= _speed * Time.deltaTime;
        }
        else if (_color.r <= 0 && _color.g >= 1 && _color.b < 1)
        {
            _color.b += _speed * Time.deltaTime;
        }
        else if (_color.r <= 0 && _color.g > 0 && _color.b >= 1)
        {
            _color.g -= _speed * Time.deltaTime;
        }
        else if (_color.r < 1 && _color.g <= 0 && _color.b >= 1)
        {
            _color.r += _speed * Time.deltaTime;
        }
        else if (_color.r >= 1 && _color.g <= 0 && _color.b > 0)
        {
            _color.b -= _speed * Time.deltaTime;
        }


        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetColor("_EmissionColor", _color);
        }
    }
}
