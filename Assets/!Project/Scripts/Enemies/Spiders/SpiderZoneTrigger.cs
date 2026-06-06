using UnityEngine;

public class SpiderZoneTrigger : MonoBehaviour
{
    //[SerializeField] private Transform _player;
    private bool _isPlayerInZone = false;
    public bool IsPlayerInZone => _isPlayerInZone;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            _isPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            _isPlayerInZone = false;
        }
    }
}
