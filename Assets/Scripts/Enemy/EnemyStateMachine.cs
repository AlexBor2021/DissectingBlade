using UnityEngine;
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Weapons _currentWeapon;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _rotationSpeed;

    private bool IsStateAttack = false;
    private float _lastAttackTime = 0;
    private Transform _target = null;

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

        if (_target != null)
        {
            Vector3 diff = _target.transform.position - transform.position;

            diff.Normalize();

            float rot = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.Euler(0, rot, 0), Time.deltaTime * _rotationSpeed);
        }
       
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
        _animator.SetBool("Shoot", false);
    }

    private void StateAttack()
    {

        _animator.SetBool("Shoot", true);
        _currentWeapon.Shoot(_currentWeapon.ShootPosition, _target.position);
    }
  
}
