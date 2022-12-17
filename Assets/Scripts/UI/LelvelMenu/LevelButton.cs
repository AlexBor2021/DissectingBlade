using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private MenuLevel _menuLevel;
    [SerializeField] private int _numberLevel;

    public void Init(MenuLevel menuLevel, int number)
    {
        _menuLevel = menuLevel;
        _numberLevel = number;
    }

    public void LoadLevel()
    {
        _menuLevel.LoadLevel(_numberLevel);
    }
}
