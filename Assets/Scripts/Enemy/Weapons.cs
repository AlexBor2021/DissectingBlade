using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] public float Delay;
    [SerializeField] public Transform ShootPosition;
    [SerializeField] protected Bullet Bullet;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public abstract void Shoot(Transform shootPoint, Vector3 target);

    public void Buy()
    {
        _isBuyed = true;
    }

}
