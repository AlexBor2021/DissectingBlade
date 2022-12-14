using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Weapons _currentWeapon;
    [SerializeField] private LayerMask _layerMask;

    private bool IsStateAttack = false;
    private float _lastAttackTime = 0;
    private Transform _target = null;
    private void Update()
    {
        if (_lastAttackTime <= 0)
        {

            if (IsStateAttack)
            {

                if (CanSeeTarget(_currentWeapon.ShootPosition.position, _target.position))
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

            _target = other.transform;
            IsStateAttack = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<LimbPlayer>())
        {
            _target = other.transform;
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

    public bool CanSeeTarget(Vector3 direction, Vector3 origin)
    {
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity, _layerMask))
        {

            if (hit.collider.TryGetComponent(out LimbPlayer player))
            {
                return true;
            }
        }

        return false;
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(_currentWeapon.ShootPosition.position, _target.position);
    //}
}
