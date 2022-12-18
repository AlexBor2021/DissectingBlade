using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class FinishIcon : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countEnemy;
    [SerializeField] private TextMeshProUGUI _countBoss;
    [SerializeField] private TextMeshProUGUI _coinCount;
    [SerializeField] private GameObject _enemyIcon;
    [SerializeField] private GameObject _coinIcon;
    [SerializeField] private GameObject _bossIcon;
    [SerializeField] private List<Animator> _animatorsStar;

    private int _numberSceneLevelMenu = 2;
   
    public void TakeInfo(float countEnemy, float countBoss,int revard, int countStars)
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

        _coinIcon.SetActive(true);
        _coinCount.text = "x " + revard.ToString();

        SetStars(countStars);
    }

    public void LoadlevelMenu()
    {
        SceneManager.LoadScene(_numberSceneLevelMenu);
    }

    private void SetStars(int countStars)
    {
        for (int i = 0; i < countStars; i++)
        {
            _animatorsStar[i].enabled = true;
        }
    }
}
