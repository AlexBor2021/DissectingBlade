using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExplosion : MonoBehaviour
{
    [SerializeField] private DestroyWall destroyWall;
    
    private DestroyWall test;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            test.Explosion();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            test = Instantiate(destroyWall, transform.position, Quaternion.identity);
        }
    }
}
