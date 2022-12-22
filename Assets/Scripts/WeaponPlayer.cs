using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{
    [SerializeField] int _damage;

    private EnemyBoss _enemyBoss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyBoss>(out _enemyBoss))
        {
            _enemyBoss.TakeDamage(_damage);
        }
    }
}
