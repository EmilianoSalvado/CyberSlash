using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] int _healthValue;
    public int HealthValue { get { return _healthValue; } }
    [SerializeField] int _defaultHealthValue;

    [SerializeField] int _maxEnergyValue;
    public int MaxEnergyValue { get { return _maxEnergyValue; } }
    [SerializeField] int _defaultMaxEnergyValue;


    public static Shop instance;

    public void FakeStart()
    {
        if (PlayerPrefs.HasKey("HealthShopValue"))
        {
            _healthValue = PlayerPrefs.GetInt("HealthShopValue");
        }
        SetStrings.instance.SetHealthShopValue();
    }

    public void Reset()
    {
        _healthValue = _defaultHealthValue;
        SetStrings.instance.SetHealthShopValue();
    }

    public void IncreasePlayerHealth()
    {
        if (PlayerDataManager.instance.Coins < _healthValue)
        {
            return;
        }

        var newValue = PlayerDataManager.instance.Health * 1.2f;
        PlayerPrefs.SetFloat("Health", newValue);
        PlayerDataManager.instance.CallPrefs();
        PlayerDataManager.instance.SpendCoin(_healthValue);
        _healthValue *= 2;
        PlayerPrefs.SetInt("HealthShopValue", _healthValue);
        PlayerPrefs.Save();
        SetStrings.instance.SetHealthShopValue();
    }

    public void IncreaseEnergy()
    {
        EnergyManager.instance.AddEnergy();
    }

    public void IncreaseMaxEnergy()
    {
        if (PlayerDataManager.instance.Coins < _maxEnergyValue)
        {
            return;
        }
        EnergyManager.instance.IncreaseMaxEnergy();
        PlayerDataManager.instance.SpendCoin(_maxEnergyValue);
        _maxEnergyValue *= 2;
    }
}
