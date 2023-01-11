using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private int _maxHealth;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Material _diePlayer;
    [SerializeField] private AudioSource _hit;

    private Material _livePlayer;
    private MovePhysick _movePhysick;
    private int _health;
    private int _maxArmor;
    private int _currentArmor;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
        _movePhysick = GetComponent<MovePhysick>();
    }

   
    public void TakeDamage(int damage)
    {
        if (_health <= 0)
        {
            _movePhysick.ISMenu = true;
            Time.timeScale = 0.2f;
            _livePlayer = _skinnedMeshRenderer.material;
            _skinnedMeshRenderer.material = _diePlayer;
            Invoke(nameof(PlayerDead), 1);
        }
        else
        {
            _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
            HealthChanged?.Invoke(_health, _maxHealth);
            _hit.Play();
        }
    }

    public void Heal(int health)
    {
        if (_health != _maxHealth)
        {
            _health = Mathf.Clamp(_health + health, 0, _maxHealth);
            HealthChanged?.Invoke(_health, _maxHealth);
        }
        else if(_health == _maxHealth)
        {
            _health = Mathf.Clamp(_health + health, 0, _maxHealth);
            HealthChanged?.Invoke(_health, _maxHealth);
            _skinnedMeshRenderer.material = _livePlayer;
        }
    }
    public void ResurrectionPlayer()
    {
        _health = _maxHealth;
        Heal(_maxHealth);
    }

    private void PlayerDead()
    {
        _losePanel.SetActive(true);
    }

}
