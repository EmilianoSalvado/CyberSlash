using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] float  _rotationSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
    }
}
