using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private GameObject _effectChest;
    [SerializeField] private GameObject _healthOrb;
    [SerializeField] private AudioSource _openChest;

    private const string _open = "Open";
    private bool _isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>() && _isOpen == false)
        {
            _animator.SetTrigger(_open);
            _pointer.DeletePointer();
            _isOpen = true;
            _effectChest.SetActive(true);
            _healthOrb.SetActive(true);
            _openChest.Play();
        }
    }
}
