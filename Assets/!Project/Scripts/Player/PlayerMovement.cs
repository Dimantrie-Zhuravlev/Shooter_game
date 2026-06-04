using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField, Range(6, 12f)] private float _baseSpeed = 6f;
    [SerializeField, Range(12f, 18f)] private float _shiftSpeed = 12f;
    [SerializeField] private Transform _mainCamera;

    private Vector2 _inputDirection;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = _baseSpeed;
    }
    private void FixedUpdate()
    {
        if (_inputDirection != Vector2.zero) //вектор отличен от нулевого
        {
            HandleMovement();
        }
        else
        {
            _rb.linearVelocity = new Vector3(0f, _rb.linearVelocity.y, 0f);
        }
    }

    private void HandleMovement()
    {
        Vector3 cameraForward = _mainCamera.forward;
        Vector3 cameraRight = _mainCamera.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movementDirection = cameraForward * _inputDirection.y + cameraRight * _inputDirection.x;
        movementDirection.Normalize();
        _rb.linearVelocity = new Vector3(movementDirection.x * currentSpeed, _rb.linearVelocity.y, movementDirection.z * currentSpeed);
    }
    public void OnShiftRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentSpeed = _shiftSpeed;
        }
        else if (context.canceled)
        {
            currentSpeed = _baseSpeed;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _inputDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _inputDirection = Vector2.zero;
        }

    }
}
