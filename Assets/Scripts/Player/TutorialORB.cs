using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialORB : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>())
        {
            gameObject.SetActive(false);
        }
    }
}
