using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.GraphicsBuffer;

public class PlayerRotation : AbstractInputAbility
{
    [SerializeField] private float _maxVerticalAngle = 75f;
    [SerializeField, Range(-15f, -80f)] private float _minVerticalAngle = -75f;
    [SerializeField, Range(1f, 360f)] private float _turnSpeed = 30f;

    [Header("Позиции объектов")]
    [SerializeField] private Transform _orbitalCamera;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _hand;
    [SerializeField] private Transform _handPoint;

    private Vector2 _orbitAngles;
    private void Awake()
    {
        _orbitAngles = new Vector2(90, 90);
    }
    void Update()
    {

        Vector3 cameraForward = _orbitalCamera.forward;
        Vector3 cameraRight = _orbitalCamera.right;
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward, Vector3.up);

        _body.transform.rotation = Quaternion.Euler(0f, _orbitAngles.y, 0f);
        _orbitalCamera.rotation = Quaternion.Euler(_orbitAngles.x, _orbitAngles.y, 0f);

        if (_hand != null)
        {
            _hand.rotation = Quaternion.Euler(_orbitAngles.x, _orbitAngles.y, 0f) * Quaternion.Euler(0f, 180f, 0f); //последние 180 т.к. оружие изначально перевернуто
            _handPoint.position = new Vector3(_hand.position.x, _hand.position.y - _orbitAngles.x / 150f, _hand.position.z);
        }
    }

    public override void AbilityActivatePerformed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        float deltaX = input.x;
        float deltaY = -input.y;

        _orbitAngles.x += deltaY * _turnSpeed * Time.unscaledDeltaTime;
        _orbitAngles.y += deltaX * _turnSpeed * Time.unscaledDeltaTime;

        _orbitAngles.x = Mathf.Clamp(_orbitAngles.x, _minVerticalAngle, _maxVerticalAngle);
        _orbitAngles.y = Mathf.Repeat(_orbitAngles.y, 360f); //362 градуса конвертируется в 2
    }

    public override void AbilityActivateCanceled(InputAction.CallbackContext context) { }
}
