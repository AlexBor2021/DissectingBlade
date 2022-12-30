using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLuze : MonoBehaviour
{
    [SerializeField] private GameObject _musicFon;

    private void OnEnable()
    {
        _musicFon.SetActive(false);
    }
}
