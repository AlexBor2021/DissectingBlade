using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private TimerLelvel _timerLelvel;
    [SerializeField] private FinishIcon _finishIcon;
    [SerializeField] private ContainerEnemy _containerEnemy;
    [SerializeField] private GameObject _unlockFinish;
    [SerializeField] private int _revardConst;

    private int _countStars;
    private int _revard;

    private void Update()
    {
        if (_containerEnemy.ChekingOfExecution())
        {
            _unlockFinish.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<LimbPlayer>(out LimbPlayer limbPlayer))
        {
            _timerLelvel._isStartTimer = false;
            _finishIcon.TakeInfo(_containerEnemy.CountEnemyKill, _containerEnemy.CountBossKill, _revard, _countStars);
            _finishIcon.gameObject.SetActive(true);
        }
    }

    public void CalculatingStarsAndRevard(int countStars)
    {
        if (countStars == 0)
        {
            Time.timeScale = 0;
            _countStars = 0;
            _revard = 0;
            _finishIcon.TakeInfo(_containerEnemy.CountEnemyKill, _containerEnemy.CountBossKill, _revard, _countStars);
            _finishIcon.gameObject.SetActive(true);
        }
        else
        {
            _countStars = countStars;
            _revard =_revardConst * countStars;
        }
    }
}
