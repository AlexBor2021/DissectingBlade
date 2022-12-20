using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _enemy;
    [SerializeField] private Material _dieMatirial;
    [SerializeField] private PuppetMaster _puppetMasterSettings;
    [SerializeField] private List<GameObject> _limbs;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private DieEnemy _dieEnemy;
    
    private int _numberLayerEnemy = 3;

    public event UnityAction<Enemy> DiedEnemy;
    public bool IsDie;

    public void EnemyDie(int limbNum)
    {
        _puppetMasterSettings.state = PuppetMaster.State.Dead;
        foreach (var limb in _limbs)
        {
            limb.layer = _numberLayerEnemy;
        }
        _enemy.material = _dieMatirial;
        IsDie = true;
        DiedEnemy?.Invoke(this);
        _pointer.DeletePointer();
        Instantiate(_dieEnemy, transform.position, transform.rotation).TearLimb(limbNum);
        Destroy(gameObject);
    }
}
