using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerManager : MonoBehaviour
{
    [SerializeField] private IconPointer _prefabIcon;
    
    private Transform _player;
    private Dictionary<Pointer, IconPointer> _dictionary = new Dictionary<Pointer, IconPointer>();
    private Camera _camera;

    public static PointerManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _camera = Camera.main;
        _player = FindObjectOfType<Player>().transform;
    }

    private void LateUpdate()
    {

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        
        foreach (var pointAndIcon in _dictionary)
        {
            Pointer pointer = pointAndIcon.Key;
            IconPointer iconPointer = pointAndIcon.Value;

            Vector3 diractionPoint = pointer.transform.position - _player.position;
            Ray ray = new Ray(_player.position, diractionPoint);

            float minDisatance = Mathf.Infinity;
            int planeIndex = 0;

            for (int i = 0; i < 4; i++)
            {
                if (planes[i].Raycast(ray, out float distance))
                {
                    if (distance < minDisatance)
                    {
                        minDisatance = distance;
                        planeIndex = i;
                    }
                }
            }

            minDisatance = Mathf.Clamp(minDisatance, 0, diractionPoint.magnitude);
            
            Vector3 worldPosition = ray.GetPoint(minDisatance);
            Vector3 position = _camera.WorldToScreenPoint(worldPosition);
            Quaternion rotation = SetRotateIconPointer(planeIndex);

            if (diractionPoint.magnitude > minDisatance)
            {
                iconPointer.Show();
            }
            else
            {
                iconPointer.Hide();
            }

            iconPointer.SetPositionAndRotation(position, rotation);
        }
    }
    public void AddToList(Pointer pointer)
    {
        IconPointer iconPointer = Instantiate(_prefabIcon, transform);
        iconPointer.SetImage(((int)pointer.IndexSpriteCurrent));
        _dictionary.Add(pointer, iconPointer);
    }
    public void RemoveToList(Pointer pointer)
    {
        Destroy(_dictionary[pointer].gameObject);
        _dictionary.Remove(pointer);
    }
    private Quaternion SetRotateIconPointer(int indexPlane)
    {
        if (indexPlane == 0)
        {
            return Quaternion.Euler(0f, 0f, 90f);
        }
        else if (indexPlane == 1)
        {
            return Quaternion.Euler(0f, 0f, -90f);
        }
        else if (indexPlane == 2)
        {
            return Quaternion.Euler(0f, 0f, 180f);
        }
        else if (indexPlane == 3)
        {
            return Quaternion.Euler(0f, 0f, 0f);
        }

        return Quaternion.identity;
    }
}
