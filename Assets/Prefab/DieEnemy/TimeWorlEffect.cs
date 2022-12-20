using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class TimeWorlEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private float _timeWork;

    private float _dalayTime;
    private void OnEnable()
    {
        _particle.Play();
    }
    private void Update()
    {
        _dalayTime += Time.deltaTime;
        
        if (_dalayTime >= _timeWork)
        {
            _particle.Stop();
        }
    }


}
