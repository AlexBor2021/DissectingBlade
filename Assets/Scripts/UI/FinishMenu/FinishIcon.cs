using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class FinishIcon : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countEnemy;
    [SerializeField] private TextMeshProUGUI _countBoss;
    [SerializeField] private GameObject _enemyIcon;
    [SerializeField] private GameObject _bossIcon;
    
    [SerializeField] private List<Animator> _animatorsStar;

    private int _numberSceneLevelMenu = 2;
    private float _valueOneStar = 0.3f;
    private float _valueTwoStars = 0.6f;
    private float _valueThreeStars = 1f;

    public void TakeInfo(float countEnemy, float countBoss, float excution)
    {
        if (countEnemy > 0)
        {
            _enemyIcon.SetActive(true);
            _countEnemy.text = "x " + countEnemy.ToString();
        }

        if (countBoss > 0)
        {
            _bossIcon.SetActive(true);
            _countBoss.text = "x " + countBoss.ToString();
        }

        SetStars(excution);
    }

    public void LoadlevelMenu()
    {
        SceneManager.LoadScene(_numberSceneLevelMenu);
    }

    private void SetStars(float excution)
    {
        int numberStars;

        if (excution >= _valueThreeStars)
        {
            numberStars = 3;
        }
        else if (excution >= _valueTwoStars)
        {
            numberStars = 2;
        }
        else if (excution >= _valueOneStar)
        {
            numberStars = 1;
        }
        else
        {
            numberStars = 0;
        }


        for (int i = 0; i < numberStars; i++)
        {
            _animatorsStar[i].enabled = true;
        }

    }
}
