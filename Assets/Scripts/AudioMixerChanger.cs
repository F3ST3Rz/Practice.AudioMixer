using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerChanger : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const string EffectsVolume = nameof(EffectsVolume);

    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private float _currentMasterVolume = 1f;
    private float _minVolume = 0.0001f;
    private bool _isToggleMaster = true;
    private float _offsetVolume = 20f;
    
    public void ToggleVolumeMaster(bool enabled)
    {
        _isToggleMaster = enabled;

        if (enabled)
            ChangeVolume(MasterVolume, _currentMasterVolume);
        else
            ChangeVolume(MasterVolume, _minVolume);
    }

    public void ChangeVolumeMaster(float volume)
    {
        _currentMasterVolume = volume;

        if (_isToggleMaster)
            ChangeVolume(MasterVolume, volume);     
    }

    public void ChangeVolumeMusic(float volume)
    {
        ChangeVolume(MusicVolume, volume);
    }

    public void ChangeVolumeEffects(float volume)
    {
        ChangeVolume(EffectsVolume, volume);
    }

    private void ChangeVolume(string groupVolume, float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat(groupVolume, Mathf.Log10(volume) * _offsetVolume);
    }
}
