using UnityEngine;

public class GunBoneFollower : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _hand;// Привяжите MainCamera сюда
    [SerializeField] private float _smoothSpeed = 10f;     // Плавность привязки к кости
    [SerializeField] private float _cameraFollowSpeed = 15f; // Плавность поворота к камере
    [SerializeField] private float _verticalOffset = 0.1f; // Небольшое опускание для реалистичности

    private void LateUpdate()
    {
        if (_cameraTransform == null) return;

        // 1. Получаем позицию и поворот кости RightHand
        //Vector3 targetPosition = _hand.position;
        //targetPosition.y -= _verticalOffset - 3.45f; // Опускаем оружие немного ниже кости для естественности

        //// 2. Плавное перемещение к кости
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _smoothSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, _hand.rotation, Time.deltaTime * _smoothSpeed);

        // 3. Поворачиваем оружие по горизонтали к камере (только по Y)
        Vector3 cameraForward = _cameraTransform.forward;
        Vector3 horizontalForward = new Vector3(cameraForward.x, cameraForward.y, cameraForward.z).normalized;

        if (horizontalForward.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(horizontalForward, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _cameraFollowSpeed);
        }
    }
}
