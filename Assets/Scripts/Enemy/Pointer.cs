using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public IndexSprite IndexSpriteCurrent = IndexSprite.Enemy;

    public enum IndexSprite 
    {
        Enemy,
        Chest,
        Finish,
    };

    private void Start()
    {
        PointerManager.Instance.AddToList(this);
    }

    

}
