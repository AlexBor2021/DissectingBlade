using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _forseExplosion;
    [SerializeField] private GameObject _gameObjectNotDestroy;
    [SerializeField] private GameObject _gameObjectDestroy;
    [SerializeField] private List<Rigidbody> _rigidbodiesDestroy;
    [SerializeField] private Transform _plaseExplosion;
    [SerializeField] private bool _isBomb;


    private Collider[] _overlappedColiders;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Weapon>(out Weapon weapon) || other.TryGetComponent<LimbPlayer>(out LimbPlayer limbPlayer))
        {
            Explosion();
        }
    }
    public void Explosion()
    {
        _gameObjectNotDestroy.SetActive(false);
        _gameObjectDestroy.SetActive(true);

        _overlappedColiders = Physics.OverlapSphere(_plaseExplosion.position, _radius);

        foreach (var rb in _rigidbodiesDestroy)
        {
            rb.AddExplosionForce(_forseExplosion, _plaseExplosion.position, _radius);
        }

        if (_isBomb)
        {
            foreach (var collider in _overlappedColiders)
            {
                if (collider.TryGetComponent<Enemy>(out Enemy enemy))
                {

                }
            }
        }

        Invoke("OffObject", 3f);
    }

    private void OffObject()
    {
        gameObject.SetActive(false);
    }
}
