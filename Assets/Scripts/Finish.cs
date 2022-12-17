using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private FinishIcon _finishIcon;
    [SerializeField] private ContainerEnemy _containerEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _finishIcon.gameObject.SetActive(true);
            _finishIcon.TakeInfo(_containerEnemy.CountEnemyKill, _containerEnemy.CountBossAfter, _containerEnemy.ÑalculationOfExecution());
        }
    }
}
