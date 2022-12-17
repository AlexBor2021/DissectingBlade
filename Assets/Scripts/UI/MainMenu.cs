using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _button;

    private void OnEnable()
    {
#if UNITY_WEBGL && YANDEX_GAMES
        AuthtirizeIfNeed();
#endif
    }
    private void AuthtirizeIfNeed()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            _button.SetActive(true);
        }
        else if (PlayerAccount.HasPersonalProfileDataPermission == false)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
        }
    }
    
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadTutorial()
    {

    }

    public void Authtorize()
    {
        PlayerAccount.Authorize(AuthorizeTrue, EroorAuthorize);
        PlayerAccount.RequestPersonalProfileDataPermission();

        void AuthorizeTrue()
        {
            Debug.Log("player authorize !");
        }

        void EroorAuthorize(string eror)
        {
            Debug.Log(eror + "player not authorize !");
        }
    }
}
