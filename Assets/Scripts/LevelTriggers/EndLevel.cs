using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerDataManager.instance.EndLevel();
        GameMenu.instance.EndGameVictory();
    }
}
