using UnityEngine;

public class MoveArrowPosition : MonoBehaviour
{
    [SerializeField] private LayerMask _arrowRayCAst;
    [SerializeField] private Transform _main;
    
    private float _angle;

    public Vector2 DiractionForPlayer;
    public float AngleRotate => _angle;

    private void LateUpdate()
    {
        RotateArrow();
    }
    private void RotateArrow()
    {
        Vector2 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        Physics.Raycast(castPoint, out RaycastHit raycastHit, _arrowRayCAst);

        Vector2 diraction = raycastHit.point - transform.position;
        DiractionForPlayer = diraction;
        _angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle - 90);

        _main.localScale = new Vector3(0.2f, DiractionForPlayer.magnitude, 0);
        
    }
}