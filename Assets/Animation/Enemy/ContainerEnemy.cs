using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Transform _bossContainer;

    private float _countEnemyBefore;
    private float _countEnemyKill;
    private float _countBossBefore;
    private float _countBossKill;

    public float CountEnemyKill => _countEnemyKill;
    
    public float CountBossAfter => _countBossKill;

    private void OnEnable()
    {
        _countEnemyBefore = _enemyContainer.childCount;
        _countBossBefore = _bossContainer.childCount;

        for (int i = 0; i < _countEnemyBefore; i++)
        {
            _enemyContainer.GetChild(i).GetComponent<Enemy>().DiedEnemy += DeidEnemy;
        }
    }

    public float ÑalculationOfExecution()
    {
        float exution = _countEnemyKill/ _countEnemyBefore;
        return  exution ;
    }

    private void DeidEnemy(Enemy enemy)
    {
        _countEnemyKill++;
        enemy.DiedEnemy -= DeidEnemy;
    }

    private void DeidBoss()
    {

    }


}
