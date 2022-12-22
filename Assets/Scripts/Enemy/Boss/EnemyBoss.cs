using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _enemyBossMesh;
    [SerializeField] private Material _dieMatirial;
    [SerializeField] private PuppetMaster _puppetMasterSettings;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private int _health;

    public bool IsDie;
    public int Health => _health;

    public void EnemyBossDie()
    {
        _puppetMasterSettings.state = PuppetMaster.State.Dead;
        _enemyBossMesh.material = _dieMatirial;
        _pointer.DeletePointer();
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
