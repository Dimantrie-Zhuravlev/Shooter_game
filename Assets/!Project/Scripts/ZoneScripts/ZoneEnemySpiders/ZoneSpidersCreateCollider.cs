using TMPro;
using UnityEngine;

public class ZoneSpidersCreateCollider : MonoBehaviour
{
    [SerializeField] private ButtonSpidersCreate _spidersCreate;
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private TMP_Text _infoMessage;

    private bool isPlayerInZone = false;

    private void OnTriggerEnter(Collider other)
    {
        isPlayerInZone = true;
    }
    public void OnCLickInteract()
    {
        RaycastHit hit;
        if (isPlayerInZone && Physics.Raycast(_mainCamera.transform.position, _mainCamera.forward, out hit, 5f, _layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider && hit.collider.gameObject.TryGetComponent<ButtonSpidersCreate>(out var enemy))
            {
                _spidersCreate.CreateSpiders();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInZone = false;
        _infoMessage.text = "";
    }
    private void OnTriggerStay(Collider other)
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(_mainCamera.transform.position, _mainCamera.forward, out hit, 5f, _layerMask, QueryTriggerInteraction.Ignore);
        if (hasHit)
        {
            if (hit.collider && hit.collider.gameObject.TryGetComponent<ButtonSpidersCreate>(out var enemy))
            {
                _infoMessage.text = "Нажмите E";
            }
            else
            {
                _infoMessage.text = "";
            }
        } else
        {
            _infoMessage.text = "";
        }
    }
}
