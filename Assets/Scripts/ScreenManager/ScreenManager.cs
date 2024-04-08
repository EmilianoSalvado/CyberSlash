using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;

    [SerializeField] Transform _mainGameRoot;
    [SerializeField] Transform _pauseMenuRoot;
    [SerializeField] Transform _endGameRoot;
    [SerializeField] Transform _configRoot;
    Stack<IScreen> _screensStack;

    public enum Screens { Main, Pause, End, Config}

    Screen _main;
    Screen _pause;
    Screen _end;
    Screen _config;

    Dictionary<Screens, Screen> _screensDictionary;

    private void Start()
    {
        _screensStack = new Stack<IScreen>();

        _main = new Screen(_mainGameRoot);
        _pause = new Screen(_pauseMenuRoot);
        _end = new Screen(_endGameRoot);
        _config = new Screen(_configRoot);

        _screensDictionary = new Dictionary<Screens, Screen>();

        _screensDictionary.Add(Screens.Main, _main);
        _screensDictionary.Add(Screens.Pause, _pause);
        _screensDictionary.Add(Screens.End, _end);
        _screensDictionary.Add(Screens.Config, _config);

        PushScreen(_main);
    }

    public void Push(Screens screen)
    {
        PushScreen(_screensDictionary[screen]);
    }

    void PushScreen(IScreen screen)
    {
        if (_screensStack.Count > 0)
            _screensStack.Peek().Deactivate();

        _screensStack.Push(screen);
        screen.Activate();
    }

    public void Pop()
    {
            if (_screensStack.Count <= 1) return;

            _screensStack.Pop().Deactivate();
                   
            _screensStack.Peek().Activate();
    }
}
