using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbDieEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _limbRoot;
    [SerializeField] private GameObject _prefabLimb;

    public void TearLimb()
    {
        _limbRoot.SetActive(false);
        gameObject.SetActive(false);
        var limb = Instantiate(_prefabLimb, transform.position, Quaternion.identity);
    }
}
