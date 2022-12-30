using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class TutorialORB : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private FinishTutorial _finishTutorial;
    [SerializeField] private AudioSource _bonus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>())
        {
            _pointer.DeletePointer();
            _bonus.Play();
            if(_finishTutorial != null)
                _finishTutorial.DeleteBall();
            gameObject.SetActive(false);
        }
    }
}
