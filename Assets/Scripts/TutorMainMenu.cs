using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorMainMenu : MonoBehaviour
{
    private const string _tutor = "Tutor";
    private bool _isShow;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(_tutor) > 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameObject.SetActive(false);
            PlayerPrefs.SetInt(_tutor, 1);
        }
    }
}
