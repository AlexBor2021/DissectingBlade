using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class MovePhysick : MonoBehaviour
{
    [SerializeField] private Rigidbody _limbPlayerMove;
    [SerializeField] private Animator _animator;
    [SerializeField] private MoveArrowPosition _arrow;
    [SerializeField] private Transform _armatura;
    [SerializeField] private float _forseDoll;
    [SerializeField] private float _timerForForseDoll;

    private float _pastTime;
    private Vector2 _diraction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OffAnimatorPlayer();
            _pastTime = 0;
            _arrow.gameObject.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _diraction = _arrow.DiractionForPlayer.normalized;
            _arrow.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_pastTime <= _timerForForseDoll)
        {
            _pastTime++;
            _limbPlayerMove.AddForce(new Vector3(_diraction.x, _diraction.y, 0) * _forseDoll);
        }
    }

    private void OffAnimatorPlayer()
    {
        _animator.enabled = false;
    }
}
