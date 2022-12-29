using System.Collections.Generic;
using UnityEngine.Audio;
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
    [SerializeField] private AudioSource _destroySound;

    private Collider[] _overlappedColiders;
    private bool _isOne = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ListWeaponsPlayer>(out ListWeaponsPlayer weapon) || other.TryGetComponent<LimbPlayer>(out LimbPlayer limbPlayer))
        {
            if (_isOne)
            {
                _isOne = false;
                Explosion();
                _destroySound.Play();
            }
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
                    enemy.EnemyDie(1);
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
