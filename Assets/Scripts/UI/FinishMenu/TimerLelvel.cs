using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerLelvel : MonoBehaviour
{
    [SerializeField] private List<float> _timesLevelEnd;
    [SerializeField] private TextMeshProUGUI _secondTimer;
    [SerializeField] private TextMeshProUGUI _minsTimer;
    [SerializeField] private Finish _finish;
    
    private int _mins = 0;
    private float _timeLeft;
    private const int _secondsIninutes = 60;
    
    private void OnEnable()
    {
        _timeLeft = _timesLevelEnd[2];
        _secondTimer.text = _timesLevelEnd[2].ToString();
    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        TimerDrow();
    }

    public void StopTimerPlayer()
    {
        _finish.FinishedPlayer(SetStars());
    }

    
    private void TimerDrow()
    {
        if (_timeLeft > _timesLevelEnd[1])
        {
            _minsTimer.color = Color.green;
            _secondTimer.color = Color.green;
        }
        else if (_timeLeft > _timesLevelEnd[0])
        {
            _minsTimer.color = Color.yellow;
            _secondTimer.color = Color.yellow;
        }
        else if(_timeLeft > 0)
        {
            _minsTimer.color = Color.red;
            _secondTimer.color = Color.red;
        }
        else
        {
            _minsTimer.color = Color.gray;
            _secondTimer.color = Color.gray;
        }

        if (_timeLeft > 9.5f)
        {
            _secondTimer.text = _timeLeft.ToString("f0");
        }
        else if(_timeLeft > 0.5f)
        {
            _secondTimer.text = 0 + _timeLeft.ToString("f0");
        }
        else
        {
            _secondTimer.text = "00";
        }
    }

    private int SetStars()
    {
        if (_timeLeft > _timesLevelEnd[1])
        {
            return 3;
        }
        else if (_timeLeft > _timesLevelEnd[0])
        {
            return 2;
        }
        else if (_timeLeft > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
