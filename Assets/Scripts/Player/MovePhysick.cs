using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class MovePhysick : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;
    [SerializeField] private Rigidbody _limbPlayerMove;
    [SerializeField] private List<Rigidbody> _limbsPlayer;
    [SerializeField] private MoveArrowPosition _arrow;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _skelet;
    [SerializeField] private Transform _armatura;
    [SerializeField] private float _forse = 5;
    [SerializeField] private float _forseDoll = 5;
    [SerializeField] private float _timerForForseDoll = 10;

    private float _pastTime;
    private Vector2 _diraction;
    
    private bool _move = false;
    private bool _moveDoll = false;
    private bool _isWall = false;


    private void Awake()
    {
        SwitchKinematic(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("GetKeyDown");
            _pastTime = 0;
            _arrow.gameObject.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("GetKeyUp");
            transform.rotation = Quaternion.Euler(0, 0, _arrow.AngleRotate - 90);
            ChekOnWall();
            _arrow.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Debug.Log(other.name + " enter");
            _isWall = true;
            _move = false;
            SwitchKinematic(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            Debug.Log(other.name + " exit");
            _isWall = false;
        }
    }

    private void Move()
    {
        _diraction = _arrow.DiractionForPlayer.normalized;

        if (_move)
        {
            Debug.Log("NOTdie");
            _player.AddForce(new Vector3(_diraction.x, _diraction.y, 0) * _forse);
        }
        else if (_moveDoll && _pastTime <= _timerForForseDoll)
        {
            transform.position = _skelet.position;

            if (_pastTime <= _timerForForseDoll)
            {
                Debug.Log("die");
                _pastTime++;
                _limbPlayerMove.AddForce(new Vector3(_diraction.x, _diraction.y, 0) * _forseDoll);
            }
        }
    }

    private  void SwitchKinematic(bool kinrmatic)
    {
        if (kinrmatic)
        {
            _skelet.SetParent(_armatura);
            _player.isKinematic = false;
        }
        else
        {
            _player.isKinematic = true;
            _skelet.SetParent(null);
        }

        foreach (var limb in _limbsPlayer)
        {
            limb.isKinematic = kinrmatic;
        }

        _animator.enabled = kinrmatic;
    }

    private void ChekOnWall()
    {
        if (_isWall)
        {
            _move = false;
            _moveDoll = true;
        }
        else
        {
            _moveDoll = false;
            _move = true;
            SwitchKinematic(true);
        }
    }
}
