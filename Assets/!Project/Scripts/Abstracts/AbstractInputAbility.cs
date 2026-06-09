using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AbstractInputAbility : MonoBehaviour
{
    public abstract void AbilityActivatePerformed(InputAction.CallbackContext context);
    public abstract void AbilityActivateCanceled(InputAction.CallbackContext context);
}
