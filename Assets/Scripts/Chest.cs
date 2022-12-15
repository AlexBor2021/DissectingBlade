using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Pointer _pointer;

    private const string _open = "Open";
    private bool _isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>() && _isOpen == false)
        {
            _animator.SetTrigger(_open);
            _pointer.DeletePointer();
            _isOpen = true;
        }
    }
}
