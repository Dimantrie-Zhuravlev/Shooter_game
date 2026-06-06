using UnityEngine;

public class EnemyAbilityDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isPeriodDamage;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var player))
        {
            if (isPeriodDamage) { player.TakePeriodicalDamage(damage);  }
            else
            {
                player.TakeDamage(damage);
            }
        }
    }
}
