using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField, Range(0, 10f)] private float _groundAcceleration = 4f;

    public void Move(Vector3 direction)
    {
        Vector3 maximalVelocity = direction * _groundAcceleration;
        Vector3 currentVelocity = _rb.linearVelocity;
        float verticalSpeed = currentVelocity.y;
        currentVelocity.y = 0;

        float deltaAcceleration = _groundAcceleration * Time.fixedDeltaTime;
        currentVelocity = Vector3.MoveTowards(currentVelocity, maximalVelocity, deltaAcceleration);
        currentVelocity.y = verticalSpeed;

        _rb.linearVelocity = currentVelocity;
    }
}
