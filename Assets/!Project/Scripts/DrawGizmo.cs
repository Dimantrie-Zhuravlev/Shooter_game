using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private float raycastCameraDistance;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.greenYellow;
        Gizmos.DrawRay(_mainCamera.transform.position, _mainCamera.forward * raycastCameraDistance); //направленые камеры персонажа
    }
}
