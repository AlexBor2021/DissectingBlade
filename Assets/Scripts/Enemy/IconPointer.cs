using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconPointer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private List<Sprite> _sprites;

    public void SetImage(int indexSprite)
    {
        _image.sprite = _sprites[indexSprite];
    }

    public void Show()
    {
        _image.enabled = true;
    }

    public void Hide()
    {
        _image.enabled = false;
    }
    public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
}
