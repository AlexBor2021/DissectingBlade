using Agava.VKGames;
using Agava.VKGames.Samples;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKIntialize : MonoBehaviour
{
    private IEnumerator  Start()
    {
         DontDestroyOnLoad(this.gameObject);

#if UNITY_WEBGL && YANDEX_GAMES && !UNITY_EDITOR

        yield return YandexGamesSdk.Initialize();
#else
        SceneManager.LoadScene(1);
#endif
        yield return null;
    }

}
