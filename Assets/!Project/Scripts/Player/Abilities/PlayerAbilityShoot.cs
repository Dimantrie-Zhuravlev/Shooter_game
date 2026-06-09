using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : AbstractInputAbility
{
    [SerializeField] private BulletsPool _bulletsPool;
    
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private GunsController _gunsController;
    

    public override void AbilityActivateCanceled(InputAction.CallbackContext context) { }
    public override void AbilityActivatePerformed(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        _gunsController.Shoot();
        bool hasHit = Physics.Raycast(_mainCamera.transform.position, _mainCamera.forward, out hit, raycastDistance, _enemyLayerMask, QueryTriggerInteraction.Ignore);
        if (hasHit && _gunsController.AbilityEnable)
        {
            if (hit.collider && hit.collider.gameObject.TryGetComponent<EnemyHealth>(out var enemy))
            {
                enemy.TakeDamage(_gunsController.CurrentDamage);
            }
            else
            {
                if (hit.collider.gameObject.layer != 9)
                { //это заглушка чтобы пули друг на друга не накладывались
                    Vector3 directionIntoSurface = -_mainCamera.transform.forward;
                    Quaternion baseRotation = Quaternion.LookRotation(directionIntoSurface, hit.normal);
                    Quaternion finalRotation = baseRotation * Quaternion.FromToRotation(Vector3.forward, Vector3.up);
                    _bulletsPool.Get(hit.point, finalRotation);
                }

            }
        }
    }
}
