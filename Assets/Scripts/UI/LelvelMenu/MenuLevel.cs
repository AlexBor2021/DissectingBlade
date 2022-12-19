using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] private GameObject _containerLevels;

    private int _corectNumber = 3;


    private void OnEnable()
    {
        for (int i = 0; i < _containerLevels.transform.childCount; i++)
        {
            _containerLevels.transform.GetChild(i).GetComponent<LevelButton>().Init(this, i);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + _corectNumber);
    }
}