using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitherOnOff : MonoBehaviour
{
    [SerializeField] private GameObject _objectForOnOff;
   
    public void Switch()
    {
        if (_objectForOnOff.activeSelf)
        {
            _objectForOnOff.SetActive(false);
        }
        else
        {
            _objectForOnOff.SetActive(true);
        }
    }
   
}
