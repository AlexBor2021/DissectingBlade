using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Weapons _currentWeapon;
    [SerializeField] private LayerMask _layerMask;

    private bool IsStateAttack = false;
    private float _lastAttackTime = 0;
    private Transform _target;
    private void Update()
    {
        if (_lastAttackTime <= 0)
        {

            if (IsStateAttack)
            {
                Debug.Log("Враг в зоне");

                if (CanSeeTarget((_currentWeapon.ShootPosition.position - _target.position).normalized,_currentWeapon.ShootPosition.position))
                {
                    Debug.Log("Стрельба");
                    StateAttack();
                    _lastAttackTime = _currentWeapon.Delay;
                }
               
            }

        }
        _lastAttackTime -= Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>())
        {
            Debug.Log("Враг в nhbutht");

            _target = other.transform;
            IsStateAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
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
        _currentWeapon.Shoot(_currentWeapon.ShootPosition);
    }

    public bool CanSeeTarget(Vector3 direction, Vector3 origin)
    {
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity, _layerMask))
        {
            Debug.Log(hit.collider.name);

            if (hit.collider.TryGetComponent(out Player player))
            {
                return true;
            }
        }

        return false;
    }
}
