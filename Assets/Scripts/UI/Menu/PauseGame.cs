using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
   private MovePhysick _movePhysick;

    public  void SetPause()
    {
        _movePhysick = FindObjectOfType<MovePhysick>();
        _movePhysick.ISMenu = true;
        Time.timeScale = 0;
    }
    public void RemovePause()
    {
        _movePhysick.ISMenu = false;
        Time.timeScale = 1;
    }
}
