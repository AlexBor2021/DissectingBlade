using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] private GameObject _containerLevels;

    private int _corectNumber = 3;
    private int _nextlevel = 1;

    private void OnEnable()
    {
        ManagerInfoGame.CurrentLevel -= _corectNumber;
        _nextlevel += ManagerInfoGame.CurrentLevel;

        for (int i = 0; i < _containerLevels.transform.childCount; i++)
        {
            _containerLevels.transform.GetChild(i).GetComponent<Level>().Init(this, i);
            
            if (i == ManagerInfoGame.CurrentLevel && ManagerInfoGame.IsLevelCompled)
            {
                _containerLevels.transform.GetChild(i).GetComponent<Level>().SetStars(ManagerInfoGame.CountStarsForLevel);
                _containerLevels.transform.GetChild(_nextlevel).GetComponent<Level>().UnlockLevel();
            }
        }

        ManagerInfoGame.ZeroInfo();
        _nextlevel = 0;
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + _corectNumber);
    }
}
