using UnityEngine;

public class EnemyAbilityDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isPeriodDamage;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var player = hit.gameObject.GetComponentInParent<PlayerHealth>();
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
