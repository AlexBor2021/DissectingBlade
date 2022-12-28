using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] private GameObject _containerLevels;
    [SerializeField] private GeneralMarketing _generalMarketing;

    private int _numberMenuScene = 1;

    private void OnEnable()
    {
        for (int i = 0; i < _containerLevels.transform.childCount; i++)
        {
            _containerLevels.transform.GetChild(i).GetComponent<Level>().LoadInfolevel();
            
            if (_containerLevels.transform.GetChild(i).GetComponent<Level>().IsComlite)
            {
                int nextLevel = i;
                nextLevel++;

                _containerLevels.transform.GetChild(nextLevel).GetComponent<Level>().UnlockLevel();
            }
        }

        _generalMarketing.ShowBaner();
    }
    
    public void Exit()
    {
        SceneManager.LoadScene(_numberMenuScene);
    }
}
