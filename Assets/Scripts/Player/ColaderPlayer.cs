using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaderPlayer : MonoBehaviour
{
    [SerializeField] private MovePhysick _movePhysick;

    private bool _move;
    private bool _moveDoll;
    private bool _doll;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
        {
            Debug.Log(other.name + " stay");
            _doll = true;
            _move = false;
            //_movePhysick.SwitchPhisic(false);
        }
        
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Wall")
    //    {
    //        Debug.Log("exit");
    //        _move = true;
    //        _doll = false;
    //        _movePhysick.SwitchPhisic(false);
    //    }
    //}
}
