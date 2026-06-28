using UnityEngine;

public class VerticalStair : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        _playerMovement.ChangeIsPlayerVerticalStair(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _playerMovement.ChangeIsPlayerVerticalStair(false);
    }
}
