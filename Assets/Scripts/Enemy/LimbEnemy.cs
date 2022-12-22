using System;
using UnityEngine;

public class LimbEnemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _blood;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Limbs limbs;

    private EnemyBoss _enemyBoss;

    public bool IsBoss;
    
    private enum Limbs
    {
        Head,
        Body,
        LeftArm,
        RigtArm,
        LeftLeg,
        RightLeg
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsBoss ==false)
        {
            if (collision.gameObject.GetComponent<WeaponPlayer>() && _enemy.IsDie == false)
            {
                Vector3 positionContact = collision.contacts[0].point;
                Quaternion rotationContact = Quaternion.LookRotation(collision.contacts[0].normal);
                Instantiate(_blood, positionContact, Quaternion.Inverse(rotationContact));
                _enemy.EnemyDie(((int)limbs));
            }
        }
        else if(collision.gameObject.GetComponent<WeaponPlayer>())
        {
            Vector3 positionContact = collision.contacts[0].point;
            Quaternion rotationContact = Quaternion.LookRotation(collision.contacts[0].normal);
            Instantiate(_blood, positionContact, Quaternion.Inverse(rotationContact));
        }
    }
}
