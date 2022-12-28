using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Pistol : Weapons
{
    [SerializeField] private AudioSource _shoot;
    public override void Shoot(Transform shootPoint, Vector3 target)
    {
        Vector3 direction =  target - shootPoint.position;
        Bullet bullet = Instantiate(Bullet, shootPoint.position, Quaternion.LookRotation(direction, Vector3.up));
        _shoot.Play();
        bullet.SetTarget(target);
    }
}
