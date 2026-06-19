using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GunsController _gunsController;
    [SerializeField] private ZoneSpidersCreateCollider _zoneSpiderButton;
    [SerializeField] private ChangePlayerMaterial _changeMaterial;
    [SerializeField] private bool _needChangeMaterial;
    [Header("Abilities")]
    [SerializeField] private PlayerAbilityShoot _abilityShoot;
    [SerializeField] private PlayerMovement _abilityMove;
    [SerializeField] private PlayerAbilityRun _abilityRun;
    [SerializeField] private PlayerAbilityJump _abilityJump;
    [SerializeField] private PlayerRotation _lookCamera;
    [SerializeField] private PlayerAbilityCrouch _abilityCrouch;

    public static PlayerController Instance { get; set; }


    private void Start()
    {
        Instance = this;
    }

    public void PlayerShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _abilityShoot.AbilityActivatePerformed(context);
            if (_needChangeMaterial)
            {
                _changeMaterial.ChangeMaterial();
            }
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _abilityMove.AbilityActivatePerformed(context);
        }
        else if (context.canceled)
        {
            _abilityMove.AbilityActivateCanceled(context);
        }
    }

    public void OnShiftRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _abilityRun.AbilityActivatePerformed(context);
        }
        else if (context.canceled)
        {
            _abilityRun.AbilityActivateCanceled(context);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _abilityJump.AbilityActivatePerformed(context);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookCamera.AbilityActivatePerformed(context);
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _gunsController.AbilityActivatePerformed(context);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _zoneSpiderButton.OnCLickInteract();
        }
    }

    public void OnSitdown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _abilityCrouch.AbilityActivatePerformed(context);
        }
    }


}
