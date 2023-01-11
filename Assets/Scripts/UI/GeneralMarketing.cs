using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Agava.YandexGames;

public class GeneralMarketing : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private FinishIcon _finishIcon;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private int _minRevard;
    [SerializeField] private int _maxRevard;
    [SerializeField] private PanelRevard _chestPanel;

    private const string _masterSound = "MasterVolume";

    public void ShowInstalateForHP()
    {
        //VideoAd.Show(OffMusicVolume, Revard, OnMusicVolume);
        
        //void OffMusicVolume()
        //{
        //    Time.timeScale = 0;
        //    _audioMixer.SetFloat(_masterSound, -80);
        //}
        //void OnMusicVolume()
        //{
        //    Time.timeScale = 1;
        //    _audioMixer.SetFloat(_masterSound, 0);
        //}

        //void Revard()
        //{
        //    _player.ResurrectionPlayer();
        //}
        _player.ResurrectionPlayer();
    }

    public void ShowInstalateForCoinX2()
    {
        VideoAd.Show(OffMusicVolume, Revard, OnMusicVolume);

        void OffMusicVolume()
        {
            Time.timeScale = 0;
            _audioMixer.SetFloat(_masterSound, -80);
        }
        void OnMusicVolume()
        {
            Time.timeScale = 1;
            _audioMixer.SetFloat(_masterSound, 0);
        }

        void Revard()
        {
            _finishIcon.DoublingCoin();
        }
    }
    public void ShowInstalateForCoinrandom()
    {
        int revard = Random.Range(_minRevard, _maxRevard);
        
        VideoAd.Show(OffMusicVolume, Revard, OnMusicVolume);
        
        void OffMusicVolume()
        {
            Time.timeScale = 0;
            _audioMixer.SetFloat(_masterSound, -80);
        }
        void OnMusicVolume()
        {
            Time.timeScale = 1;
            _audioMixer.SetFloat(_masterSound, 0);
            _chestPanel.SetText(revard);
        }

        void Revard()
        {
            ManagerInfoGame.AddCoinInWalletPlayer(revard);
        }
    }

    public void ShowBaner()
    {
        InterstitialAd.Show();
    }
}
