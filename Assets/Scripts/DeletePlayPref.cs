using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayPref : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}
