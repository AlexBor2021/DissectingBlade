using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Weapons _currentWeapon;
    [SerializeField] private LayerMask _layerMask;

    private bool IsStateAttack = false;
    private float _lastAttackTime = 0;
    private Transform _target = null;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {

            if (IsStateAttack && !_enemy.IsDie)
            {
                    StateAttack();
                    _lastAttackTime = _currentWeapon.Delay;
            }

        }
        _lastAttackTime -= Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>())
        {

            _target = other.transform;
            IsStateAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<LimbPlayer>())
        {
            IsStateAttack = false;
            StateIdle();
        }
    }

    private void StateIdle()
    {

    }

    private void StateAttack()
    {
        _currentWeapon.Shoot(_currentWeapon.ShootPosition, _target.position);
    }
  
}
