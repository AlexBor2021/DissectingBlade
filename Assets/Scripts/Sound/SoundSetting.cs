using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Image _offMusic;
    [SerializeField] private Image _onMusic;
    [SerializeField] private Image _offEffect;
    [SerializeField] private Image _onEffect;
    [SerializeField] private Slider _music;
    [SerializeField] private Slider _effect;
    

    private const string _musicVolume = "MusicVolume";
    private const string _effectVolume = "EffectVolume";
    private const string _masterVolume = "MasterVolume";

    public void ChangeVolumeMusic()
    {
        _audioMixerGroup.audioMixer.SetFloat(_musicVolume, Mathf.Lerp(-80, 0, _music.value));
        
        if (_music.value == 0)
        {
            _offMusic.enabled = true;
            _onMusic.enabled = false;
        }
        else
        {
            _offMusic.enabled = false;
            _onMusic.enabled = true;
        }
    }
    public void ChangeVolumeEffect()
    {
        _audioMixerGroup.audioMixer.SetFloat(_musicVolume, Mathf.Lerp(-80, 0, _effect.value));

        if (_effect.value == 0)
        {
            _offEffect.enabled = true;
            _onEffect.enabled = false;
        }
        else
        {
            _offEffect.enabled = false;
            _onEffect.enabled = true;
        }
    }
}
