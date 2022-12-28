using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using RootMotion.Dynamics;
using UnityEngine.Events;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _enemyBossMesh;
    [SerializeField] private StateMachineBoss _stateMachineBoss;
    [SerializeField] private Material _dieMatirial;
    [SerializeField] private PuppetMaster _puppetMasterSettings;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private int _health;
    [SerializeField] private AudioSource _deadVouse;

    public bool IsDie;
    public int Health => _health;
    public event UnityAction<EnemyBoss> DieBoss;

    private void Update()
    {
        if (_health <= 0 )
        {
            EnemyBossDie();
            _deadVouse.Play();
        }
    }
    public void EnemyBossDie()
    {
        _puppetMasterSettings.state = PuppetMaster.State.Dead;
        _enemyBossMesh.material = _dieMatirial;
        _stateMachineBoss.enabled = false;
        _pointer.DeletePointer(); 
        DieBoss?.Invoke(this);
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
