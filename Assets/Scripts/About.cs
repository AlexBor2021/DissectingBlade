using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class About : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    private void OnEnable()
    {
        _music.Stop();
    }

    private void OnDisable()
    {
        _music.Play();
    }
}
