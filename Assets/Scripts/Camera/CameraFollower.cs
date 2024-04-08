using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _offset;

    private void Start()
    {
        transform.forward = -_offset;
    }

    private void Update()
    {
        transform.position = _target.position + _offset;
    }
}
