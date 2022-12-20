using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerLelvel : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private List<float> _timesLevelEnd;
    [SerializeField] private TextMeshProUGUI _secondTimer;
    [SerializeField] private TextMeshProUGUI _minsTimer;
    
    private int _mins = 0;
    private float _dalayTime;
    private float _dalayTimeForCalculating;
    private const int _secondsIninutes = 60;

    public bool _isStartTimer;

    private void OnEnable()
    {
        _dalayTime = _timesLevelEnd[2];
        _secondTimer.text = _timesLevelEnd[2].ToString();
    }

    private void Update()
    {
        if (_isStartTimer)
        {
            _dalayTimeForCalculating += Time.deltaTime;

            TimerDrow();
        }
        else
        {
            _finish.CalculatingStarsAndRevard(SetStars());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<LimbPlayer>(out LimbPlayer limbPlayer))
        {
            _isStartTimer = true;
        }
    }

    private void TimerDrow()
    {
        if (_dalayTime > 0)
        {
            if (_dalayTime > 10)
            {
                _dalayTime -= Time.deltaTime;
                _secondTimer.text = _dalayTime.ToString("f0");
            }
            else
            {
                _dalayTime -= Time.deltaTime;
                _secondTimer.text = 0 + _dalayTime.ToString("f0");
            }
        }
        else
        {
            if (_mins > 0)
            {
                _mins--;
                _minsTimer.text = _mins.ToString();
                _dalayTime = 0;
            }
            else
            {
                _isStartTimer = false;
            }
        }
    }

    private int SetStars()
    {
        if (_dalayTimeForCalculating < _timesLevelEnd[2])
        {
            return 3;
        }
        else if (_dalayTimeForCalculating < _timesLevelEnd[1])
        {
            return 2;
        }
        else if (_dalayTimeForCalculating < _timesLevelEnd[0])
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
