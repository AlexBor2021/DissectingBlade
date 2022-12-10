using UnityEngine;

public class MoveArrowPosition : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _arrowRayCAst;
    [SerializeField] private Transform _main;

    private float _angle;
    private Vector3 _point; 

    public Vector3 DiractionForPlayer;

    public float AngleRotate => _angle;
    public Vector3 Point => _point;


    private void Update()
    {
        RotateArrow();
    }
    private void RotateArrow()
    {
        Vector2 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        Physics.Raycast(castPoint, out RaycastHit raycastHit, _arrowRayCAst);
        _point = raycastHit.point;
       
        Vector3 diraction = raycastHit.point - transform.position;
        DiractionForPlayer = diraction;
        _angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle-90);

        Debug.Log(DiractionForPlayer.magnitude);
        
        _main.localScale = new Vector3(0.2f, DiractionForPlayer.magnitude, 0);


    }
}