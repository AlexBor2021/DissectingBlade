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
    private float _dalayTime;
    private float _dalayTimeForCalculating;
    private const int _secondsIninutes = 60;
    private bool _isStartTimer;


    private void Update()
    {
        if (_isStartTimer)
        {
            _dalayTimeForCalculating += Time.deltaTime;

            TimerDrow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<LimbPlayer>(out LimbPlayer limbPlayer))
        {
            _isStartTimer = true;
        }
    }

    public void StopTimerPlayer()
    {
        _isStartTimer = false;
        _finish.FinishedPlayer(SetStars());
    }

    private void TimerDrow()
    {
        if (_dalayTime < _secondsIninutes)
        {
            if (_dalayTime > 10)
            {
                _dalayTime += Time.deltaTime;
                _secondTimer.text = _dalayTime.ToString("f0");
            }
            else
            {
                _dalayTime += Time.deltaTime;
                _secondTimer.text = 0 + _dalayTime.ToString("f0");
            }
        }
        else
        {
            _mins++;
            _minsTimer.text = _mins.ToString();
            _secondTimer.text = "00";
            _dalayTime = 0;
        }
    }

    private int SetStars()
    {
        if (_dalayTimeForCalculating < _timesLevelEnd[0])
        {
            return 3;
        }
        else if (_dalayTimeForCalculating < _timesLevelEnd[1])
        {
            return 2;
        }
        else if (_dalayTimeForCalculating < _timesLevelEnd[2])
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
