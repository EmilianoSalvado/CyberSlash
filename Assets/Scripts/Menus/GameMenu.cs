using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;

    [SerializeField] GameObject _endGameScreen;
    [SerializeField] GameObject[] _nextLevelButtons;
    [SerializeField] GameObject _victory;
    [SerializeField] GameObject _failure;
    [SerializeField] GameObject _PauseMenu;

    public void EndGameVictory()
    {
        _victory.SetActive(true);

        for (int i = 0; i < _nextLevelButtons.Length; i++)
        {
            _nextLevelButtons[i].SetActive(!_nextLevelButtons[i].activeSelf);
        }

        ScreenManager.instance.Push(ScreenManager.Screens.Main);
    }

    public void EndGameFailure()
    {
        _failure.SetActive(true);

        ScreenManager.instance.Push(ScreenManager.Screens.End);
    }

    public void Pause()
    {
        if (_victory.activeSelf || _failure.activeSelf)
            return;

        ScreenManager.instance.Push(ScreenManager.Screens.Pause);
    }

    public void Config()
    {
        ScreenManager.instance.Push(ScreenManager.Screens.Config);
    }

    public void Back()
    {
        ScreenManager.instance.Pop();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
