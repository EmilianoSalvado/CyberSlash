using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDataSave", menuName = "Scriptables/AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField] float _masterVolume;
    public float MasterVolume { get { return _masterVolume; } }
    [SerializeField] bool _musicOn;
    public bool MusicOn { get { return _musicOn; } }
    [SerializeField] float _volumeSliderValue;
    public float VolumeSliderValue { get { return _volumeSliderValue; } }

    public void SetMasterVolume(float f)
    {
        _masterVolume = f;
    }

    public void SetMusicOn(bool b)
    {
        _musicOn = b;
    }

    public void SetVolumeSliderValue(float f)
    {
        _volumeSliderValue = f;
    }
}
