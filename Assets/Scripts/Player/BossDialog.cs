using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDialog : MonoBehaviour
{
    [SerializeField] private GameObject Dialog;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LimbPlayer>())
        {
            Dialog.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
