using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityJump : AbstractInputAbility
{
    [Header("Параметры")]
    [SerializeField, Range(0, 10f)] private float _groundJumpHeight = 3f;
    [SerializeField, Range(0, 10f)] private float _airJumpHeight = 2f;
    [Header("Ссылки")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerMovement _playerMove;

    

    private bool _isJumping = false;
    private bool isGrounded;

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            HandleJump();
        }
    }
    private void HandleJump()
    {
        Jump();
        _isJumping = false;
    }

    private bool _hasDoubleJumped = false;

    public void Jump()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            ApplyJumpForce(_groundJumpHeight);
            _hasDoubleJumped = true;
        }
        else if (_hasDoubleJumped)
        {
            ApplyJumpForce(_airJumpHeight);
            _hasDoubleJumped = false;
        }
    }

    private void ApplyJumpForce(float jumpHeight)
    {
        _playerMove.PlayerVelocity = new Vector3(_playerMove.PlayerVelocity.x, _playerMove.PlayerVelocity.y + Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), _playerMove.PlayerVelocity.z) ;
    }
    public override void AbilityActivatePerformed(InputAction.CallbackContext context)
    {
        _isJumping = true;
    }

    public override void AbilityActivateCanceled(InputAction.CallbackContext context) {}
}