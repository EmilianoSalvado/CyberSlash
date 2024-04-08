using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetStrings : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _totalCoins;
    [SerializeField] TextMeshProUGUI _currentCoins;
    [SerializeField] TextMeshProUGUI _currentHits;
    [SerializeField] TextMeshProUGUI _healthShopValue;
    [SerializeField] TextMeshProUGUI _maxEnergyShopValue;
    [SerializeField] TextMeshProUGUI _currentEnergy;
    [SerializeField] Image _healthBar;

    public static SetStrings instance;

    public void GetCalled()
    {
        if (_totalCoins != null)
            SetTotalCoins();
        if (_currentCoins != null)
            SetCurrentCoins();
        if (_currentEnergy != null)
            SetCurrentEnergy();
    }

    public void SetTotalCoins()
    {
        _totalCoins.text = PlayerDataManager.instance.Coins.ToString();
    }

    public void SetCurrentCoins()
    {
        _currentCoins.text = PlayerDataManager.instance.CurrentCoins.ToString();
    }

    public void SetCurrentHits(int i)
    {
        _currentHits.text = i.ToString();
    }

    public void SetHealthShopValue()
    {
        _healthShopValue.text = Shop.instance.HealthValue.ToString();
    }

    public void SetMaxEnergyShopValue()
    {
        _maxEnergyShopValue.text = Shop.instance.MaxEnergyValue.ToString();
    }

    public void SetCurrentEnergy()
    {
        if (_currentEnergy != null)
            _currentEnergy.text = EnergyManager.instance.Energy.ToString();
    }

    public void SetHealthBar(float maxH, float currentH)
    {
        _healthBar.fillAmount = currentH / maxH;
    }
}
