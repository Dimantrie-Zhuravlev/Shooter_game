using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField, Range(0, 10f)] private float _groundAcceleration = 4f;
    [SerializeField] public float rotationSpeed = 60f;
    [Header("Ссылки")]
    [SerializeField] private CharacterController controller;

    private Vector3 enemyVelocity;

    public void Move(Vector3 direction)
    {
        if (controller.isGrounded && enemyVelocity.y < 0)
        {
            enemyVelocity.y = 0f;
        }
        // 2. Обрабатываем горизонтальное движение
        HandleHorizontalMovement();
        // 3. Применяем гравитацию
        enemyVelocity.y += Physics.gravity.y * Time.deltaTime;

        controller.Move(enemyVelocity * Time.deltaTime);
    }
    private void HandleHorizontalMovement()
    {
        Vector3 desiredMoveDirection = gameObject.transform.forward + gameObject.transform.right;
        // Устанавливаем горизонтальную скорость. Вертикальная (y) остается прежней.
        //enemyVelocity.x = desiredMoveDirection.x * _groundAcceleration;

        enemyVelocity.x = transform.forward.x * _groundAcceleration;
        enemyVelocity.z = transform.forward.z * _groundAcceleration;
    }

    public void RotateToPlayer(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
    }
}
