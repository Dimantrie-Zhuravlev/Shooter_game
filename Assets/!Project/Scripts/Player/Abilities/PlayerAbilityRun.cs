using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityRun : AbstractInputAbility
{
    [SerializeField] private PlayerMovement _abilityMovement;
    public override void AbilityActivateCanceled(InputAction.CallbackContext context)
    {
        _abilityMovement.SetBaseSpeed();
    }
    public override void AbilityActivatePerformed(InputAction.CallbackContext context)
    {
        _abilityMovement.SetShiftSpeed();
    }
}