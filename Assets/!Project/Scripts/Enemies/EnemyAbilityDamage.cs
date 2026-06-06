using UnityEngine;

public class EnemyAbilityDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isPeriodDamage;
    private void OnCollisionStay(Collision collision)
    {
        var player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            if (isPeriodDamage)
            {
                player.TakePeriodicalDamage(damage);
            }
            else
            {
                player.TakeDamage(damage);
            }
        }
    }
}
