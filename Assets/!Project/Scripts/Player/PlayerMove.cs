using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Vector2 _inputDirection;
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private PlayerMovement _objectMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (_inputDirection != Vector2.zero) //вектор отличен от нулевого
        {
            HandleMovement();
        } else
        {
            _objectMovement.Stop();
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


        //Vector3 movementDirection = Vector3.forward * _inputDirection.y + Vector3.right * _inputDirection.x; //y и x  это пользовательский ввод
        Vector3 movementDirection = cameraForward * _inputDirection.y + cameraRight * _inputDirection.x;
        movementDirection.Normalize();
        _objectMovement.Move(movementDirection);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed) //удерживается ли кнопка зажатой
        {
            _inputDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _inputDirection = Vector2.zero;
        }

    }
}
