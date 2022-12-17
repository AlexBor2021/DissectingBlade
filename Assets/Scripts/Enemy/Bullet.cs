using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    private Vector3 _target;
    public void SetTarget(Vector3 target)
    {
        _target = target;
        
    }

    private void Update()
    {
      transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
