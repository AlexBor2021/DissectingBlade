using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerButtonSet : MonoBehaviour
{
    [SerializeField] private List<WeaponShop> _weaponShops;

    private WeaponShop _weaponShop;

    public void LoadInfo()
    {
        for (int i = 0; i < transform.childCount-1; i++)
        {
            _weaponShops[i].LoadInfo();
        }
    }
}
