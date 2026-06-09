using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityJump : AbstractInputAbility
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField, Range(0, 10f)] private float _groundJumpHeight = 3f;
    [SerializeField, Range(0, 10f)] private float _airJumpHeight = 2f;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private float raycastDistance = 0.51f;
    [SerializeField] private Transform _playerBody;

    private bool _isJumping = false;

    public bool IsGrounded()
    {
        Vector3 rayOrigin = new Vector3(
            _playerBody.transform.position.x,
            _playerBody.transform.position.y,
            _playerBody.transform.position.z
        );
        RaycastHit hit;
        bool hasHit = Physics.Raycast(rayOrigin, Vector3.down, out hit, raycastDistance); //Используется если луч должен найти не плоскость
        //RaycastHit2D hit1 = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, -1); //Используется если луч должен найти плоскость
        return hit.collider != null;
    }
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
        if (IsGrounded())
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
        var velocity = _rb.linearVelocity;
        velocity.y = velocity.y < 0f ? 0f : velocity.y;
        velocity.y += Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
        _rb.linearVelocity = velocity;
    }
    public override void AbilityActivatePerformed(InputAction.CallbackContext context)
    {
        _isJumping = true;
    }

    public override void AbilityActivateCanceled(InputAction.CallbackContext context) {}
}