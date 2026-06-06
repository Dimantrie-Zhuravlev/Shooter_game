using UnityEngine;

public class SpidersController : MonoBehaviour
{
    [SerializeField] private SpiderZoneTrigger _zoneDetector;
    [SerializeField] private PatrolPoints _patrolPoints;
    [SerializeField] private EnemiesMovement _movement;
    //[SerializeField] private EnemyShooter _shooter;

    private void Update()
    {
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
        Vector3 targetPosition = _zoneDetector.GetTargetPosition();
        Vector3 directionTarget = GetDirectionToTarget(targetPosition);
        MoveAndShoot(directionTarget, true);
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
        MoveAndShoot(directionToTarget, false);
    }
    private void MoveAndShoot(Vector3 direction, bool canShoot)
    {

        _movement.Move(direction);
        //_shooter.Shoot(canShoot);
    }
}
