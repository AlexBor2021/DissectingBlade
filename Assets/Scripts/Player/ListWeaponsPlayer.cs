using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWeaponsPlayer : MonoBehaviour
{
    [SerializeField] private int _damageDefoult;
    [SerializeField] private List<GameObject> _wepons;
    [SerializeField] private WeaponShop _weaponShop;

    private EnemyBoss _enemyBoss;
    private int _currentWeapon = 0;

    private void Awake()
    {
        PlayerPrefs.SetInt(ManagerInfoGame.WeaponShopInfo.IsBuyWeapon + _currentWeapon, 1);

        if (PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon) == 0)
        {
            _wepons[_currentWeapon].SetActive(true);
            PlayerPrefs.SetInt(ManagerInfoGame.WeaponShopInfo.IsSetWeapon + _currentWeapon, 1);
        }
        else
        {
            _currentWeapon = PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon);
            _wepons[_currentWeapon].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyBoss>(out _enemyBoss))
        {
            _enemyBoss.TakeDamage(_damageDefoult);
        }
    }

    public void SetWeapon()
    {
        _wepons[_currentWeapon].SetActive(false);
        PlayerPrefs.SetInt(ManagerInfoGame.WeaponShopInfo.IsSetWeapon+_currentWeapon, 0);
      
        _currentWeapon = PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon);
        _wepons[_currentWeapon].SetActive(true);
    }
}
