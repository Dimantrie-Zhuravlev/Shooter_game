using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAim : MonoBehaviour
{
    [SerializeField] Image _crossChair;
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask _enemyLayerMask;

    private float _lastCheckTime = 0f;
    private float _checkInterval = 0.2f;

    void Update()
    {
        if (Time.time - _lastCheckTime > _checkInterval)
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(_mainCamera.transform.position, _mainCamera.forward, out hit, raycastDistance, _enemyLayerMask, QueryTriggerInteraction.Ignore);
            if (hit.collider && hit.collider.gameObject.TryGetComponent<EnemyHealth>(out var _))
            {
                _crossChair.gameObject.SetActive(true);
            }
            else
            {
                _crossChair.gameObject.SetActive(false);
            }
            _lastCheckTime = Time.time;
        }
    }
}
