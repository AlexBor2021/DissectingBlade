using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueStarsAll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textStars;

    private int _allStars = 0;

    public void AddStars(int number)
    {
        _allStars += number;
        _textStars.text = _allStars.ToString();
    }
}
