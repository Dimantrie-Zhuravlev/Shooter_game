using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private float raycastCameraDistance;

    [SerializeField] private float raycastUnderPlayerDistance = 5f;
    [SerializeField] private Transform _playerBody;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.greenYellow;
        Gizmos.DrawRay(_mainCamera.transform.position, _mainCamera.forward * raycastCameraDistance); //направленые камеры персонажа

        // Рисуем луч (видно в Scene View без Play Mode)
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_playerBody.position, Vector3.down * raycastUnderPlayerDistance);
}
}
