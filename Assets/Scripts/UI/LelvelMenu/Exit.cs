using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void ExitInMenu()
    {
        SceneManager.LoadScene(1);
    }
}
