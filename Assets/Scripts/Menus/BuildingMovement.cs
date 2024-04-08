using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMovement : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("DestroySelf");
    }

    private void Update()
    {
        transform.position += Vector3.left * 5 * Time.deltaTime;
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
