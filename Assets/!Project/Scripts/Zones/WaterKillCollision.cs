using UnityEngine;

public class WaterKillCollision : MonoBehaviour
{
    [SerializeField] private PlayerLives _killPlayer;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            _killPlayer.LoseOneLive();
        }
    }
}
