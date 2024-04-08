using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    public void SaveGame()
    {
        PlayerPrefs.SetInt("LevelsUnlocked", PlayerDataManager.instance.LevelUnlocked);
        PlayerPrefs.SetInt("Coins", PlayerDataManager.instance.Coins);
        PlayerPrefs.SetFloat("Health", PlayerDataManager.instance.Health);
        PlayerPrefs.SetInt("NotFirstPlay", PlayerDataManager.instance.NotFirstPlay ? 1 : 0);
        PlayerPrefs.SetInt("Mostros", PlayerDataManager.instance.Mostros);

        PlayerPrefs.Save();
    }

    public void DeleteGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerDataManager.instance.SetDefaultValues();
        Shop.instance.Reset();
        SetStrings.instance.GetCalled();
    }
}