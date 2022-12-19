using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Armor _armor;

    private int _health;
    private int _maxArmor;
    private int _currentArmor;

    public event UnityAction<int, int, bool> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;

        if (_armor != null)
        {
            _maxArmor = _armor.GetArmor();
            _currentArmor = _maxArmor;
        }

    }

   
    public void TakeDamage(int damage)
    {
        if (_maxHealth<damage)
        {
            Time.timeScale = 0.5f;

            Invoke(nameof(PlayerDead), 3);
        }
        else
        {
            if (_currentArmor != 0)
            {
                _currentArmor = Mathf.Clamp(_currentArmor - damage, 0, _maxArmor);
                HealthChanged?.Invoke(_currentArmor, _maxArmor, true);
            }
            else
            {
                _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
                HealthChanged?.Invoke(_health, _maxHealth, false);
            }
        }
      
    }

    private void Heal(int health)
    {

        _health = Mathf.Clamp(_health + health, 0, _maxHealth);
        HealthChanged?.Invoke(_health, _maxHealth, false);
    }

    private void PlayerDead()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
