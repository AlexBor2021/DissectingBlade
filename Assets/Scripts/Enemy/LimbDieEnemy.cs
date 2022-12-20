using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbDieEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _limbRoot;
    [SerializeField] private GameObject _prefabLimb;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Rigidbody _prefabLimbRigiBody;

    private float _forse = 300f;

    public bool ISBody;
    public GameObject LeftLeg;
    public GameObject RightLeg;
    public void TearLimb()
    {
        _limbRoot.SetActive(false);
        _skinnedMeshRenderer.enabled = false;
        _prefabLimb.SetActive(true);
        
        if (ISBody)
        {
            LeftLeg.SetActive(false);
            RightLeg.SetActive(false);
        }
        else
        {
            _prefabLimbRigiBody.AddForce(Vector3.up * _forse);
        }
    }
}
