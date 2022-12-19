using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitherOnOff : MonoBehaviour
{
    [SerializeField] private GameObject _button;
   
    public void Switch()
    {
        if (_button.activeSelf)
        {
            _button.SetActive(false);
        }
        else
        {
            _button.SetActive(true);
        }
    }
   
}
