using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
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
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
