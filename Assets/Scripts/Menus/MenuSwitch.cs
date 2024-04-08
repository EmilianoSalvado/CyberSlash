using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitch : MonoBehaviour
{
    [SerializeField] GameObject _current;
    [SerializeField] GameObject _next;
    [SerializeField] int _sceneToChangeTo;

    public void Switch()
    {
        _next.SetActive(true);
        _current.SetActive(false);
    }

    public void ChangeScene()
    {
        if (_sceneToChangeTo < 0)
            return;

        if (!PlayerDataManager.instance.NotFirstPlay)
        { Switch(); return; }

        if (EnergyManager.instance.Energy < 0)
        { return; }

        EnergyManager.instance.UseEnergy();

        SceneManager.LoadScene(_sceneToChangeTo);
    }

    public void SetSceneToChangeTo(int i)
    {
        _sceneToChangeTo = i;
    }
}