using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class OrbitalCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _maxVerticalAngle = 75f;
    [SerializeField, Range(-15f, -80f)] private float _minVerticalAngle = -75f;
    [SerializeField, Range(1f, 360f)] private float _turnSpeed = 30f;
    [SerializeField] private Transform _weaponHolder;

    private Vector2 _orbitAngles;

    private void Awake()
    {
        _orbitAngles = new Vector2(90, 90);
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(_orbitAngles.x, _orbitAngles.y, 0f);

        Vector3 direction = rotation * Vector3.forward;
        transform.position = _playerTransform.position + new Vector3(0, 6.5f, 0);

        Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(horizontalDirection, Vector3.up);
        _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, targetRotation, Time.deltaTime * 10f); // Плавный поворот
        //RotateGunPlayer();
        transform.rotation = rotation;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        float deltaX = input.x;
        float deltaY = -input.y;

        _orbitAngles.x += deltaY * _turnSpeed * Time.unscaledDeltaTime;
        _orbitAngles.y += deltaX * _turnSpeed * Time.unscaledDeltaTime;

        _orbitAngles.x = Mathf.Clamp(_orbitAngles.x, _minVerticalAngle, _maxVerticalAngle);
        _orbitAngles.y = Mathf.Repeat(_orbitAngles.y, 360f); //362 градуса конвертируется в 2
    }
    private void RotateGunPlayer ()
    {
        Vector3 cameraForward = transform.forward;
        Vector3 horizontalForward = new Vector3(-cameraForward.x, -cameraForward.y, -cameraForward.z).normalized;
        if (horizontalForward.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(horizontalForward, Vector3.up);
            _weaponHolder.rotation = Quaternion.Slerp(_weaponHolder.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
