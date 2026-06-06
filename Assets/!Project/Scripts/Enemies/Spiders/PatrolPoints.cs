using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    [Tooltip("Точки для движений")]
    [SerializeField] private Transform[] _patrolPoints;
    [Tooltip("Расстояние до цели перед сменой")]
    [SerializeField] private float _minDistanceToTarget = 0.5f;
    private int _currentPointIndex;

    public Vector3 GetTargetPosition()
    {
        if (IsAtCurrentPatrolPoint())
        {
            NextPatrolPoint();
        }
        return _patrolPoints[_currentPointIndex].position;
    }

    public void NextPatrolPoint()
    {
        if (_patrolPoints.Length > 1)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length;
        }
    }
    public bool IsAtCurrentPatrolPoint()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPointPosition = _patrolPoints[_currentPointIndex].position;

        float distance = Vector2.Distance(
            new Vector2(currentPosition.x, currentPosition.z),
            new Vector2(targetPointPosition.x, targetPointPosition.z)
        );
        return distance < _minDistanceToTarget;
    }
}
