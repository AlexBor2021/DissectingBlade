using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Agava.YandexGames;

public class ResurrectionPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioMixer _audioMixer;

    private const string _masterSound = "MasterVolume";

    public void ShowInstalateForHP()
    {
        VideoAd.Show(OffMusicVolume, Revard, OnMusicVolume);
        
        void OffMusicVolume()
        {
            _audioMixer.SetFloat(_masterSound, -80);
        }
        void OnMusicVolume()
        {
            _audioMixer.SetFloat(_masterSound, 0);
        }

        void Revard()
        {
            _player.ResurrectionPlayer();
        }
    }
}
