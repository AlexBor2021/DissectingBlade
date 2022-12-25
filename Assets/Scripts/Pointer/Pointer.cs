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
        Tutorial,
    };

    private void Start()
    {
        PointerManager.Instance.AddToList(this);
    }

    public void DeletePointer()
    {
        PointerManager.Instance.RemoveToList(this);
    }
}
