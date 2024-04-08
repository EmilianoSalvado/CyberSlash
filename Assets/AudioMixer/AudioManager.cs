using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] string _masterVolume;
    [SerializeField] string _musicVolume;

    [SerializeField] Slider _volumeSlider;
    [SerializeField] Toggle _musicToggle;

    [SerializeField] AudioData _audioData;

    private void Start()
    {
        Instance = this;

        _audioMixer.SetFloat(_musicVolume, _audioData.MusicOn ? 0f : -80f);
        _audioMixer.SetFloat(_masterVolume, _audioData.MasterVolume);
    }

    public void ToggleMusic()
    {
        if (_musicToggle.isOn)
            _audioMixer.SetFloat(_musicVolume, 0f);
        else
            _audioMixer.SetFloat(_musicVolume, -80f);

        _audioData.SetMusicOn(_musicToggle.isOn);
    }

    public void ChangeMasterVolume()
    {
        float sv = _volumeSlider.value;

        float v = 145f * sv - 65 * (sv * sv) - 80;

        _audioMixer.SetFloat(_masterVolume, v);

        _audioData.SetMasterVolume(v);
        _audioData.SetVolumeSliderValue(sv);
    }

    public void ChangeMasterVolume(float v)
    {
        _audioMixer.SetFloat(_masterVolume, v);
    }
}
