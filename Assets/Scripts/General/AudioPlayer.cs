using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _buttonPress;
    [SerializeField] AudioClip _moneySpent;

    public void ButtonPress()
    {
        _audioSource.PlayOneShot(_buttonPress);
    }

    public void MoneySpent()
    {
        _audioSource.PlayOneShot(_moneySpent);
    }
}
