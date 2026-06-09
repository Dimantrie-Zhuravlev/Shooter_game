using UnityEngine;

public class DamageTerritory : MonoBehaviour
{
    [SerializeField] public int damage;

    private void OnTriggerStay(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            player.TakePeriodicalDamage(damage);
        }
    }
}
