using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour
{
    [SerializeField] private List<LimbDieEnemy> _limbDieEnemies;
    [SerializeField] private List<GameObject> _bloodEffects;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeWaorkAnimator;

    private float _dalayTime;

    private const string _shoot = "Shoot";

    private void Start()
    {
        _animator.SetBool(_shoot, false);
    }

    public void TearLimb(int number)
    {
        _limbDieEnemies[number].TearLimb();
        _bloodEffects[number].SetActive(true);
    }

    private void Update()
    {
        _dalayTime += Time.deltaTime;
        if (_timeWaorkAnimator <= _dalayTime)
        {
            _animator.enabled = false;
        }
    }
}
