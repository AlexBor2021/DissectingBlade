using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] private int _armor;

    public int GetArmor()
    {
        return _armor;
    }
}
