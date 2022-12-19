using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        SliderHealth.value = 1;

    }
    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;

    }
}
