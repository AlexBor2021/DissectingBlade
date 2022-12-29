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
    [SerializeField] private PauseGame _pauseGame;
    [SerializeField] private PanelRevard _panelRevard;
    [SerializeField] private int _numberLevel;

    private int _numberSceneLevelMenu = 2;
    private int _comliteLevel = 1;
    private int _revard;
    

    private void OnEnable()
    {
        _pauseGame.SetPause();
    }
    private void OnDisable()
    {
        _pauseGame.RemovePause();
    }

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

        ManagerInfoGame.SaveInfoLevel(_numberLevel, countStars, _comliteLevel);

        _revard = revard;
    }

    public void LoadlevelMenu()
    {
        ManagerInfoGame.AddCoinInWalletPlayer(_revard);
        SceneManager.LoadScene(_numberSceneLevelMenu);
    }
    public void DoublingCoin()
    {
        _revard *= 2;
        ManagerInfoGame.AddCoinInWalletPlayer(_revard);
        _panelRevard.SetText(_revard);
        _revard = 0;
    }

    private void SetStars(int countStars)
    {
        for (int i = 0; i < countStars; i++)
        {
            _animatorsStar[i].enabled = true;
        }
    }
}
