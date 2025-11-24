using Unity.Cinemachine;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private CinemachineCamera cineCam;
    
    [Header("Zoom")]
    [SerializeField] private float zoomSens = 5;
    [SerializeField] private float maxZoom = 10;
    [SerializeField] private float minZoom = 2;
    

    void FixedUpdate()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        Vector3 worldMousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = worldMousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    private void Zoom()
    {
        float zoom = Mathf.Clamp(zoomSens, minZoom,maxZoom) * Input.mouseScrollDelta.y;
        cineCam.Lens.OrthographicSize = zoom;
    }
}
