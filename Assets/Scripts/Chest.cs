using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string _open = "Open";

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _animator.SetTrigger(_open);
        }
    }
}
