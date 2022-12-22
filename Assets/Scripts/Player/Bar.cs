using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider SliderHealth;
    [SerializeField] private float _speed = 0.05f;

    private Coroutine _currentCoroutine;
    private Slider _currentSlider;
    public void OnValueChanged(int value, int maxValue)
    {
        _currentSlider = SliderHealth;

        float target = (float)value / maxValue;

        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeValue(_speed, target));
    }

    private IEnumerator ChangeValue(float speed, float target)
    {
        while (SliderHealth.value != target)
        {
            SliderHealth.value = Mathf.MoveTowards(_currentSlider.value, target, speed * Time.deltaTime);

            yield return null;
        }
    }
}
