using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Image> _imagesStars;
    [SerializeField] private GameObject _unlock;

    private MenuLevel _menuLevel;
    private int _numberLevel;
    private bool _isUnlock;

    public void Init(MenuLevel menuLevel, int number)
    {
        _menuLevel = menuLevel;
        _numberLevel = number;
    }

    public void LoadLevel()
    {
        _menuLevel.LoadLevel(_numberLevel);
    }

    public void SetStars(int numberStars)
    {
        for (int i = 0; i < numberStars; i++)
        {
            _imagesStars[i].enabled = true;
        }
    }

    public void UnlockLevel()
    {
        _unlock.SetActive(false);
    }
}
