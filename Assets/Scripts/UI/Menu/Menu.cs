using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private PauseGame _pauseGame;

    private int _numberSceneMainMenu = 1;
    private void OnEnable()
    {
        _pauseGame.SetPause();
    }
    private void OnDisable()
    {
        _pauseGame.RemovePause();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_numberSceneMainMenu);
    }
}
