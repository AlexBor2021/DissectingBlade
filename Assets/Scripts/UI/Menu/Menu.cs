using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int _numberSceneMainMenu = 1;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_numberSceneMainMenu);
    }
}
