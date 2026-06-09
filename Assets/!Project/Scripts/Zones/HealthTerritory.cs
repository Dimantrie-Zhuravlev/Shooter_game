using UnityEngine;

public class HealthTerritory : MonoBehaviour
{
    [SerializeField] public int health;

    private void OnTriggerStay(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            player.TakePeriodicalHealth(health);
        }
    }
}
