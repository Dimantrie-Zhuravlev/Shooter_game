using UnityEngine;

public class WaterKillCollision : MonoBehaviour
{
    [SerializeField] private PlayerLives _killPlayer;
    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            _killPlayer.LoseOneLive();
        }
    }
}
