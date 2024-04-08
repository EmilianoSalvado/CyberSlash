using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelsButtonsManager : MonoBehaviour
{
    [SerializeField] GameObject[] _buttons;
    [SerializeField] GameObject _lockedButton;
    [SerializeField] GameObject _levelButton;

    public static LevelsButtonsManager instance;

    public void InitializeStart()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (i < PlayerDataManager.instance.LevelUnlocked)
            {
                _buttons[i].GetComponent<MenuSwitch>().SetSceneToChangeTo(i + 1);
                _buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            }
            else
            {
                _buttons[i].GetComponent<MenuSwitch>().SetSceneToChangeTo(-1);
                _buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Locked";
            }
        }
    }
}
