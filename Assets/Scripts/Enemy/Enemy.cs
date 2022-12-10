using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _enemy;
    [SerializeField] private Material _dieMatirial;
    [SerializeField] private PuppetMaster _puppetMasterSettings;
    [SerializeField] private List<GameObject> _limbs;
    
    private const string _offEnemy = "OffEnemy";
    private int _numberLayerEnemy = 3;

    public bool IsDie;

    public void EnemyDie()
    {
        _puppetMasterSettings.state = PuppetMaster.State.Dead;
        foreach (var limb in _limbs)
        {
            limb.layer = _numberLayerEnemy;
        }
        _enemy.material = _dieMatirial;
        IsDie = true;
        Invoke(_offEnemy, 6f);
    }

    private void OffEnemy()
    {
        gameObject.SetActive(false);
    }
}
