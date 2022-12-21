using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private int _maxHealth;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Material _diePlayer;
    

    private int _health;
    private int _maxArmor;
    private int _currentArmor;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
    }

   
    public void TakeDamage(int damage)
    {
        
        if (_health <= 0)
        {
            Time.timeScale = 0.2f;
            _skinnedMeshRenderer.material = _diePlayer;
            Invoke(nameof(PlayerDead), 3);
        }
        else
        {
            _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
            HealthChanged?.Invoke(_health, _maxHealth);
        }
    }

    private void Heal(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, _maxHealth);
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    private void PlayerDead()
    {
        _losePanel.SetActive(true);
    }
}
