using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class MovePhysick : MonoBehaviour
{
    [SerializeField] private Rigidbody _limbMove;
    [SerializeField] private Animator _animator;
    [SerializeField] private MoveArrowPosition _arrow;
    [SerializeField] private Transform _hips;
    [SerializeField] private float _timerForForseDoll;

    private float _forseDoll;
    private float _maxForse = 2000;
    private float _minForse = 500;
    private float _pastTime;
    private Vector2 _diraction;
    
    public bool ISMenu;

    private void Update()
    {
        if (ISMenu == false)
        {
            SetForse();

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Time.timeScale = 0.2f;
                OnRegdoll();
                _pastTime = _timerForForseDoll;
                _arrow.gameObject.SetActive(true);

            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Time.timeScale = 1f;
                _pastTime = 0;
                _diraction = _arrow.DiractionForPlayer.normalized;
                _arrow.gameObject.SetActive(false);
            }
        }
        else
	    {
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
            _limbMove.AddForce(new Vector3(_diraction.x, _diraction.y, 0) * _forseDoll);
        }
    }

    private void OnRegdoll()
    {
        _animator.enabled = false;
        _hips.SetParent(null);
        transform.SetParent(_hips);
        _limbMove.isKinematic = false;
    }

    private void SetForse()
    {
        float forse = Mathf.InverseLerp(2f, 6f, _arrow.DiractionForPlayer.magnitude);
        _forseDoll = Mathf.Lerp(_minForse, _maxForse, forse);
    }
}
