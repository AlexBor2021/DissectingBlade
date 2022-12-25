using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialORB : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private FinishTutorial _finishTutorial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>())
        {
            _finishTutorial.DeleteBall();
            _pointer.DeletePointer();
            gameObject.SetActive(false);
        }
    }
}
