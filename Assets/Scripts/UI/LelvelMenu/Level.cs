using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Image> _imagesStars;
    [SerializeField] private GameObject _lockPanel;
    [SerializeField] private int _numberLevel;

    private bool _isComlite;
    private int _countStars;
    private int _corectLoadNumberScene = 2;

    public bool IsComlite => _isComlite;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_numberLevel + _corectLoadNumberScene);
    }

    public void UnlockLevel()
    {
        _lockPanel.SetActive(false);
    }

    public void LoadInfolevel()
    {
        _countStars = PlayerPrefs.GetInt(ManagerInfoGame.LevelInfo.CountStarsForLevel + _numberLevel);

        SetStars(_countStars);
        
        if (PlayerPrefs.GetInt(ManagerInfoGame.LevelInfo.IScompliteLevel + _numberLevel) > 0)
        {
            _isComlite = true;
        }
        else
        {
            _isComlite = false;
        }
    }
    private void SetStars(int numberStars)
    {
        _countStars = numberStars;

        for (int i = 0; i < numberStars; i++)
        {
            _imagesStars[i].enabled = true;
        }
    }
}
