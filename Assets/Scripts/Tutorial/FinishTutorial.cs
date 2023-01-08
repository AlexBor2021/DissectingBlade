using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTutorial : MonoBehaviour
{
    [SerializeField] private FinishIcon _finishIcon;
    [SerializeField] private Player _player;
    [SerializeField] private int _damagePlayer;
    [SerializeField] private int _countBall;

    private int _countStars = 3;
    private int _revard = 10;


    private void OnEnable()
    {
        _player.TakeDamage(_damagePlayer);
    }

    public void DeleteBall()
    {
        _countBall--;

        if (_countBall <= 0)
        {
            _finishIcon.TakeInfo(0, 0, _revard, _countStars);
            _finishIcon.gameObject.SetActive(true);
        }
    }
}
