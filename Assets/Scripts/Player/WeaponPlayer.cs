using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private List<GameObject> _wepons;

    private EnemyBoss _enemyBoss;
    private int _currentWeapon = 0;

    private void OnEnable()
    {
        _currentWeapon = PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon);
        _wepons[_currentWeapon].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyBoss>(out _enemyBoss))
        {
            _enemyBoss.TakeDamage(_damage);
        }
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon));

        if (_currentWeapon != PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon))
        {
            SetWeapon();
        }
    }

    private void SetWeapon()
    {
        _wepons[_currentWeapon].SetActive(false);
        _currentWeapon = PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon);
        _wepons[_currentWeapon].SetActive(true);
    }
}
