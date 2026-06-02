using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField, Range(0, 10f)] private float _speed = 6f;

    private Vector3 _desiredVelocity;
    public void Move(Vector3 direction)
    {
        if (direction.magnitude > 0.1f)
        {
            direction.Normalize();
            _rb.linearVelocity = new Vector3(direction.x * _speed, _rb.linearVelocity.y, direction.z * _speed);
        }
        else
        {
            _rb.linearVelocity = new Vector3(0f, _rb.linearVelocity.y, 0f);
        }
    }
    public void Stop()
    {
        _rb.linearVelocity = new Vector3(0f, _rb.linearVelocity.y, 0f);
    }
}
