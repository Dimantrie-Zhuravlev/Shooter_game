using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityCrouch : AbstractInputAbility
{
    private CharacterController characterController;
    private bool _isCrouching;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Transform _playerModel;


    private float _crouchHeight = 3.5f; // Высота в приседе
    private float _standingHeight = 5.0f; // Высота стоя
    private float _crouchCenterY = 3.5f; // Центр капсулы в приседе
    private float _standingCenterY = 5.0f; // Центр капсулы стоя
    private float _smoothSpeed = 10f; // Скорость приседания/вставания

    private Coroutine _crouchCoroutine;
    public Coroutine CrouchCoroutine => _crouchCoroutine;

    private void Start()
    {
        _isCrouching = false;
        characterController = gameObject.GetComponent<CharacterController>();
        //_targetCenterCollider = new Vector3(0, _standingCenterY, 0);
    }
    public override void AbilityActivateCanceled(InputAction.CallbackContext context)
    {
    }

    public override void AbilityActivatePerformed(InputAction.CallbackContext context)
    {
        if (_crouchCoroutine == null)
        {
            _crouchCoroutine = StartCoroutine(CrouchAnimation(!_isCrouching));
        }
    }

    private IEnumerator CrouchAnimation(bool shouldCrouch)
    {
        _isCrouching = shouldCrouch;
        // Определяем целевые значения в зависимости от действия
        float targetHeightCollider = shouldCrouch ? _crouchHeight : _standingHeight;
        Vector3 targetCenterCollider = shouldCrouch ? new Vector3(0, _crouchCenterY, 0) : new Vector3(0, _standingCenterY, 0);

        //float targetHeightCamera = shouldCrouch ? _standingCameraHeight : _crouchCameraHeight;
        Vector3 targetCenterCamera = shouldCrouch ? new Vector3(_camera.position.x, _camera.position.y-0.5f, _camera.position.z) : new Vector3(_camera.position.x, _camera.position.y + 0.5f, _camera.position.z);
        Vector3 targetCenterBody = shouldCrouch ? new Vector3(_playerBody.position.x, _playerBody.position.y - 0.5f, _playerBody.position.z) : new Vector3(_playerBody.position.x, _playerBody.position.y + 0.5f, _playerBody.position.z);


        Vector3 targetScale = shouldCrouch ? new Vector3(1, 3.5f, 1) : new Vector3(1, 5f, 1);
        Vector3 targetScalePosition = shouldCrouch ? new Vector3(_playerModel.position.x, _playerModel.position.y -0.25f, _playerModel.position.z) : new Vector3(_playerModel.position.x, _playerModel.position.y +0.25f, _playerModel.position.z);

        // Пока текущие значения не приблизились к целевым...
        while (Mathf.Abs(characterController.height - targetHeightCollider) > 0.01f ||
               Vector3.Distance(characterController.center, targetCenterCollider) > 0.01f)
        {
            characterController.height = Mathf.Lerp(characterController.height, targetHeightCollider, Time.deltaTime * _smoothSpeed);
            characterController.center = Vector3.Lerp(characterController.center, targetCenterCollider, Time.deltaTime * _smoothSpeed);
            _camera.position = Vector3.Lerp(_camera.position, targetCenterCamera, Time.deltaTime * _smoothSpeed);
            _playerBody.position = Vector3.Lerp(_playerBody.position, targetCenterBody, Time.deltaTime * _smoothSpeed);

            _playerModel.localScale = Vector3.Lerp(_playerModel.localScale, targetScale, Time.deltaTime * _smoothSpeed);
            _playerModel.position = Vector3.Lerp(_playerModel.position, targetScalePosition, Time.deltaTime * _smoothSpeed);

            yield return null; // Ждем следующего кадра
        }

        // Убеждаемся, что значения точно достигли цели (из-за плавности могут быть микро-отклонения)
        characterController.height = targetHeightCollider;
        characterController.center = targetCenterCollider;
        _crouchCoroutine = null;
    }

}
