using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private TimerLelvel _timerLelvel;
    [SerializeField] private FinishIcon _finishIcon;
    [SerializeField] private ContainerEnemy _containerEnemy;
    [SerializeField] private int _revardConst;

    private int _countStars;
    private int _revard;
    private const string _activatePenalFinish = "ActivatePenalFinish";

    public void FinishedPlayer(int countStars)
    {
        Time.timeScale = 0.2f;
        CalculatingStarsAndRevard(countStars);
    }

    private void CalculatingStarsAndRevard(int countStars)
    {
        if (countStars == 0)
        {
            Time.timeScale = 0;
            _countStars = 0;
            _revard = 0;
        }
        else
        {
            _countStars = countStars;
            _revard =_revardConst * countStars;
        }

        _finishIcon.TakeInfo(_containerEnemy.CountEnemyKill, _containerEnemy.CountBossKill, _revard, _countStars);
        Invoke(_activatePenalFinish, 1f);
    }

    private void ActivatePenalFinish()
    {
        _finishIcon.gameObject.SetActive(true);
    }
}
