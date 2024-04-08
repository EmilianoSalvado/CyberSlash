using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] int _energy;
    public int Energy { get { return _energy; } }

    [SerializeField] int _maxEnergy = 5;
    public int MaxEnergy { get { return _maxEnergy; } }

    [SerializeField] float _timeToRecharge = 30f;

    bool _isRecharging;

    int _notifID;

    public static EnergyManager instance;

    int _defaultEnergy = 3;
    int _defaultMaxEnergy = 5;

    DateTime _nextDT;
    DateTime _lastDT;

    [SerializeField] string _notifTitle = "Energy charged, mo**f**r!!";
    [SerializeField] string _notifText = "You got your energy full, mo**f**r, it's time to play and kick some a**!!";
    int _id;
    TimeSpan _timer;

    private void Start()
    {
        Load();

        StartCoroutine("RechargeRoutine");

        if (_energy < _maxEnergy)
        {
            _timer = _nextDT - DateTime.Now;
            NotificationsManager.instance.DisplayNotification(_notifTitle, _notifText, AddDuration(DateTime.Now, ((_maxEnergy - (_energy) + 1) * _timeToRecharge) + 1 + (float)_timer.TotalSeconds));
        }

        SetStrings.instance.SetCurrentEnergy();
    }

    public void AddEnergy()
    {
        _energy++;
        SetStrings.instance.SetCurrentEnergy();
    }

    public void IncreaseMaxEnergy()
    {
        _maxEnergy++;
        PlayerPrefs.SetInt("MaxEnergy", _maxEnergy);
        PlayerPrefs.Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Energy", _energy);
        PlayerPrefs.SetString("NextEnergyTime", _nextDT.ToString());
        PlayerPrefs.SetString("LastEnergyTime", _lastDT.ToString());

        PlayerPrefs.Save();
    }

    void Load()
    {
        if (PlayerPrefs.HasKey("Energy"))
            _energy = PlayerPrefs.GetInt("Energy");
        else
            _energy = _defaultEnergy;

        if (PlayerPrefs.HasKey("MaxEnergy"))
            _maxEnergy = PlayerPrefs.GetInt("MaxEnergy");
        else
            _maxEnergy = _defaultMaxEnergy;

        if (PlayerPrefs.HasKey("NextEnergyTime"))
            _nextDT = StringToDateTime(PlayerPrefs.GetString("NextEnergyTime"));
        if (PlayerPrefs.HasKey("LastEnergyTime"))
            _lastDT = StringToDateTime(PlayerPrefs.GetString("LastEnergyTime"));

        PlayerPrefs.Save();

        SetStrings.instance.SetCurrentEnergy();
    }

    DateTime StringToDateTime(string date)
    {
        if (string.IsNullOrEmpty(date))
            return DateTime.Now;
        else
            return DateTime.Parse(date);
    }

    public void UseEnergy()
    {
        if (_energy > 0)
        {
            Debug.Log("energy -1");
            _energy--;
            Save();

            NotificationsManager.instance.CancelNotification(_id);
            NotificationsManager.instance.DisplayNotification(_notifTitle, _notifText, AddDuration(DateTime.Now, ((_maxEnergy - (_energy) + 1) * _timeToRecharge) + 1 + (float)_timer.TotalSeconds));

            if (!_isRecharging)
            {
                _nextDT = AddDuration(DateTime.Now, _timeToRecharge);
                StartCoroutine("RechargeRoutine");
            }

            SetStrings.instance.SetCurrentEnergy();
            return;
        }
    }

    public void SetToDefault()
    {
        _energy = _defaultEnergy;
        Save();
    }

    IEnumerator RechargeRoutine()
    {
        UpdateTimer();
        _isRecharging = true;

        while (_energy < _maxEnergy)
        {
            DateTime currentTime = DateTime.Now;
            DateTime nextTime = _nextDT;

            bool staminaAdd = false;

            while (currentTime > nextTime)
            {
                if (_energy >= _maxEnergy)
                    break;

                AddEnergy();

                staminaAdd = true;

                DateTime timeToAdd = nextTime;

                if (_lastDT > nextTime)
                    timeToAdd = _lastDT;

                nextTime = AddDuration(timeToAdd, _timeToRecharge);
            }

            if (staminaAdd)
            {
                _nextDT = nextTime;
                _lastDT = DateTime.Now;
            }

            UpdateTimer();
            Save();

            yield return new WaitForEndOfFrame();
        }

        NotificationsManager.instance.CancelNotification(_id);

        _isRecharging = false;
    }

    DateTime AddDuration(DateTime date, float duration)
    {
        return date.AddSeconds(duration);
    }

    void UpdateTimer()
    {
        if (_energy >= _maxEnergy)
            return;

        _timer = _nextDT - DateTime.Now;
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            Save();
    }
}