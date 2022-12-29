using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerButtonSet : MonoBehaviour
{
    private List<WeaponShop> _weaponShops;

    private WeaponShop _weaponShop;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<WeaponShop>() != null)
            {
                _weaponShops.Add(transform.GetChild(i).GetComponent<WeaponShop>());
            }
        }
    }
}
