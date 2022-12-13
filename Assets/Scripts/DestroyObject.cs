using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _forseExplosion;
    [SerializeField] private GameObject _gameObjectNotDestroy;
    [SerializeField] private GameObject _gameObjectDestroy;
    [SerializeField] private Transform _plaseExplosion;


    private Collider[] _overlappedColiders;

    private void Awake()
    {
        _overlappedColiders = Physics.OverlapSphere(_plaseExplosion.position, _radius);
    }


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
        
        foreach (var colider in _overlappedColiders)
        {
            Rigidbody rb = colider.attachedRigidbody;
            
            if (rb)
            {
                rb.AddExplosionForce(_forseExplosion, _plaseExplosion.position, _radius);
            }
        }
        Invoke("OffObject", 3f);
    }

    private void OffObject()
    {
        gameObject.SetActive(false);
    }
}
