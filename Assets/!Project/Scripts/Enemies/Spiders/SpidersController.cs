using UnityEngine;
using UnityEngine.UI;

public class SpidersController : MonoBehaviour
{
    [SerializeField] private SpiderZoneTrigger _zoneDetector;
    [SerializeField] private PatrolPoints _patrolPoints;
    [SerializeField] RectTransform _healthBarContainer;
    [SerializeField] EnemiesMovement _enemiesMovement;

    private void Update()
    {
        RotateHealthBare();
        if (_zoneDetector.IsPlayerInZone)
        {
            PursuePlayer();
        }
        else
        {
            Patrol();
        }
    }
    private void PursuePlayer()
    {
        Vector3 targetPosition = GetTargetPosition();
        Vector3 directionTarget = GetDirectionToTarget(targetPosition);
        MoveEnemy(directionTarget, true);
    }
    private Vector3 GetDirectionToTarget(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;
        directionToTarget.y = 0f;
        directionToTarget = directionToTarget.normalized;
        return directionToTarget;
    }
    private void Patrol()
    {
        Vector3 targetPosition = _patrolPoints.GetTargetPosition();
        Vector3 directionToTarget = GetDirectionToTarget(targetPosition);
        MoveEnemy(directionToTarget, false);
    }
    private void RotateHealthBare()
    {
        // 1. Находим направление от центра врага к игроку
        Vector3 directionToPlayer = GetTargetPosition() - _healthBarContainer.position;

        // Игнорируем разницу по высоте (ось Y), чтобы полоска не наклонялась вверх-вниз,
        // а всегда оставалась горизонтальной.
        directionToPlayer.y = 0;

        // Проверка на нулевой вектор, если игрок точно над/под врагом
        if (directionToPlayer == Vector3.zero)
            return;

        // 2. Создаем кватернион, который смотрит на игрока
        Quaternion lookAtPlayer = Quaternion.LookRotation(directionToPlayer);

        // 3. Добавляем смещение в 90 градусов вокруг оси Y (вверх)
        // Умножение кватернионов применяет повороты последовательно.
        Quaternion targetRotation = lookAtPlayer * Quaternion.Euler(0, 0, 0);

        // 4. Плавно поворачиваем health bar в сторону нужной ротации
        // Используем LerpUnclamped, чтобы скорость вращения была постоянной, а не зависела от угла.
        _healthBarContainer.rotation = Quaternion.LerpUnclamped(_healthBarContainer.rotation, targetRotation, Time.deltaTime * 180f);
    }
    private void MoveEnemy(Vector3 direction, bool canShoot)
    {
        _enemiesMovement.Move(direction);
        _enemiesMovement.RotateToPlayer(direction);
    }

    public Vector3 GetTargetPosition()
    {
        return PlayerController.Instance.transform.position;
    }
}
