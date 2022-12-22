using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Transform _bossContainer;
    [SerializeField] private TimerLelvel _timerLelvel;

    private float _countEnemyBefore;
    private float _countEnemyKill;
    private float _countBossBefore;
    private float _countBossKill;

    public float CountEnemyKill => _countEnemyKill;
    
    public float CountBossKill => _countBossKill;

    private void OnEnable()
    {
        if (_enemyContainer != null)
        {
            _countEnemyBefore = _enemyContainer.childCount;

            for (int i = 0; i < _countEnemyBefore; i++)
            {
                _enemyContainer.GetChild(i).GetComponent<Enemy>().DiedEnemy += DeidEnemy;
            }
        }
        if (_bossContainer != null)
        {
            _countBossBefore = _bossContainer.childCount;

            for (int i = 0; i < _countBossBefore; i++)
            {
                _bossContainer.GetChild(i).GetComponent<EnemyBoss>().DieBoss += DeidBoss;
            }
        }
    }
    

    private void DeidEnemy(Enemy enemy)
    {
        _countEnemyKill++;
        enemy.DiedEnemy -= DeidEnemy;

        if (_countEnemyBefore == _countEnemyKill)
        {
            _timerLelvel.StopTimerPlayer();
        }
    }

    private void DeidBoss(EnemyBoss enemyBoss)
    {
        _countBossKill++;
        enemyBoss.DieBoss -= DeidBoss;

        if (_countBossBefore == _countBossKill)
        {
            _timerLelvel.StopTimerPlayer();
        }
    }


}
