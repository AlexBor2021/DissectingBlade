using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerInIconFinish : MonoBehaviour
{
    [SerializeField] private Transform _timer;

    private void OnEnable()
    {
        _timer.position = transform.position;
    }
}
