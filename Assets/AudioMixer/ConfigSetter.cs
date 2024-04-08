using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigSetter : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;
    [SerializeField] Toggle _musicToggle;
    [SerializeField] AudioData _audioData;

    private void Start()
    {
        if (_musicToggle != _audioData.MusicOn)
            _musicToggle.isOn = _audioData.MusicOn;

        _volumeSlider.value = _audioData.VolumeSliderValue;
    }
}
