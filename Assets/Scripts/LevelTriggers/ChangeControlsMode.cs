using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControlsMode : MonoBehaviour
{
    [SerializeField] ControlsManager.PlayerMode _playerMode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ControlsManager>(out ControlsManager controlsManager))
        {
            controlsManager.ChangeControls(_playerMode);
        }

        GetComponent<Collider>().enabled = false;
    }
}
