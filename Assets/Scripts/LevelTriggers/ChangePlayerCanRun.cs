using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControlsManager;

public class ChangePlayerCanRun : MonoBehaviour
{
    [SerializeField] bool _canRun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerActions>(out PlayerActions playerActions))
        {
            playerActions.SetCanRun(_canRun);
        }

        GetComponent<Collider>().enabled = false;
    }
}
