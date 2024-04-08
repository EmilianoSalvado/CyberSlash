using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagesSwitch : MenuSwitch
{
    enum Which { previous, next }
    [SerializeField] GameObject[] _array;
    int count = 0;

    private void OnEnable()
    {
        if (!PlayerDataManager.instance.NotFirstPlay)
            PlayerDataManager.instance.ToggleFirstPlayBool();

        for (int i = 1; i < _array.Length; i++)
        {
            _array[i].SetActive(false);
        }
        _array[0].SetActive(true);
        count = 0;
    }

    public void Next()
    {
        count++;
        if (count >= _array.Length)
        {
            count = 0;
            Switch();
            return;
        }
        _array[count].SetActive(true);
        _array[count-1].SetActive(false);
    }

    public void Previous()
    {
        count--;
        if (count < 0)
        {
            count = 0;
            Switch();
            return;
        }
        _array[count].SetActive(true);
        _array[count+1].SetActive(false);
    }
}
