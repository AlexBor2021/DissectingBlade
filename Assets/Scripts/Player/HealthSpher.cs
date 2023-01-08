using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpher : MonoBehaviour
{
    [SerializeField] private int countHeal = 5;
    [SerializeField] private Player _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>())
        {
            _player.Heal(countHeal);
            gameObject.SetActive(false);
        }
    }
}
