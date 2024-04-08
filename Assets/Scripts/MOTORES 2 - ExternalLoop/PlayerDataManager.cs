using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour, ICallPrefs
{
    int _energy;
    public int Energy { get { return _energy; } }

    int _levelUnlocked;
    public int LevelUnlocked { get { return _levelUnlocked; } }

    [SerializeField] int _coins;
    public int Coins { get { return _coins; } }

    float _health;
    public float Health { get { return _health; } }

    int _currentCoins;
    public int CurrentCoins { get { return _currentCoins; } }

    bool _notFirstPlay;
    public bool NotFirstPlay { get { return _notFirstPlay; } }

    int _mostros;
    public int Mostros { get { return _mostros; } }

    int _defaultLevelUnlocked = 1;
    int _defaultCoins = 10;
    float _defaultHealth = 6;
    int _defaultCurrentCoins = 0;
    bool _defaultNotFirstPlay = false;

    public static PlayerDataManager instance;

    private void Start()
    {
        if (GetComponent<SaveData>())
            SaveData.instance = GetComponent<SaveData>();
        if (GetComponent<SetStrings>())
            SetStrings.instance = GetComponent<SetStrings>();
        if (GetComponent<Shop>())
            Shop.instance = GetComponent<Shop>();
        if (GetComponent<GameMenu>())
            GameMenu.instance = GetComponent<GameMenu>();
        if (GetComponent<EnergyManager>())
            EnergyManager.instance = GetComponent<EnergyManager>();
        if (GetComponent<LevelsButtonsManager>())
            LevelsButtonsManager.instance = GetComponent<LevelsButtonsManager>();
        if (GetComponent<ScreenManager>())
            ScreenManager.instance = GetComponent<ScreenManager>();

            if (instance != null)
            Destroy(this);
        else
            instance = this;

        if (Shop.instance)
            Shop.instance.FakeStart();

        CallPrefs();

        SetStrings.instance.GetCalled();

        if (LevelsButtonsManager.instance)
            LevelsButtonsManager.instance.InitializeStart();

        if (Time.timeScale < 1)
            Time.timeScale = 1;
    }

    public void CallPrefs()
    {
        if (!PlayerPrefs.HasKey("Energy"))
        { 
            SetDefaultValues();
            return;
        }

        if (PlayerPrefs.HasKey("LevelsUnlocked"))
            _levelUnlocked = PlayerPrefs.GetInt("LevelsUnlocked");
        if (PlayerPrefs.HasKey("Coins"))
            _coins = PlayerPrefs.GetInt("Coins");
        if (PlayerPrefs.HasKey("Health"))
            _health = PlayerPrefs.GetFloat("Health");
        if (PlayerPrefs.HasKey("NotFirstPlay"))
            _notFirstPlay = PlayerPrefs.GetInt("NotFirstPlay") > 0;
        if (PlayerPrefs.HasKey("Mostros"))
            _mostros = PlayerPrefs.GetInt("Mostros");
    }

    public void AddCoin()
    {
        _currentCoins++;
    }

    public void AddMostro()
    {
        _mostros++;
    }

    public void SpendCoin(int a)
    {
        _coins -= a;
        SetStrings.instance.SetTotalCoins();
    }

    public void EndLevel()
    {
        _coins += _currentCoins;

        if (SceneManager.GetActiveScene().buildIndex == _levelUnlocked)
            _levelUnlocked++;

        ///Parche por falta de niveles
        _levelUnlocked = _levelUnlocked > 2 ? 2 : _levelUnlocked;
        ///Fin del parche :3

        SaveThisData();
    }

    public void PlayerDead()
    {
        _currentCoins = 0;
        SaveThisData();
    }

    public void SaveThisData()
    {
        SaveData.instance.SaveGame();
    }

    public void ToggleFirstPlayBool()
    {
        _notFirstPlay = true;
    }

    public void SetDefaultValues()
    {
        _levelUnlocked = _defaultLevelUnlocked;
        _coins = _defaultCoins;
        _health = _defaultHealth;
        _currentCoins = _defaultCurrentCoins;
        _notFirstPlay = _defaultNotFirstPlay;
        EnergyManager.instance.SetToDefault();
        SaveThisData();
    }
}