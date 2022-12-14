using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapons
{
    public override void Shoot(Transform shootPoint, Vector3 target)
    {
        Bullet bullet =  Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bullet.SetDirection(target);
    }
}
