using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void TakeDamage(int damage)
    {
        _player.TakeDamage(damage);
    }
}
