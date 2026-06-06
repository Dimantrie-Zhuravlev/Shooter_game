using UnityEngine;

public class SpiderZoneTrigger : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private bool _isPlayerInZone = false;
    public bool IsPlayerInZone => _isPlayerInZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out _))
        {
            _isPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out _))
        {
            _isPlayerInZone = false;
        }
    }

    public Vector3 GetTargetPosition()
    {
        return transform.position;
    }
}
