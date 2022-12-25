using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _iconFinish;

    private int _countBall;

    private void OnEnable()
    {
        _countBall = transform.childCount;
        Debug.Log(_countBall);
    }

    public void DeleteBall()
    {
        _countBall--;

        if (_countBall <= 0)
        {
            _iconFinish.SetActive(true);
        }
    }
}
