using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LimbEnemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _blood;
    [SerializeField] private Enemy _enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Weapon>() && _enemy.IsDie == false)
        {
            Vector3 positionContact = collision.contacts[0].point;
            Quaternion rotationContact = Quaternion.LookRotation(collision.contacts[0].normal);
            Instantiate(_blood, positionContact, Quaternion.Inverse(rotationContact));
            _enemy.EnemyDie();
        }
    }
    
}
