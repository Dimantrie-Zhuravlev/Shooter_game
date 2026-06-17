using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerLives : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private int _maxLives = 3;

    [Header("Ссылки")]
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private Transform _pointToRestore;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private SceneSwitcher _sceneSwitcher;


    private int currentLives;

    void Start()
    {
        currentLives = _maxLives;
        DisplayLives();
    }

    private void DisplayLives()
    {
        _livesText.text = $"{currentLives}";
    }

    private IEnumerator DeadEnumerator()
    {
        yield return new WaitForSeconds(2);
        _sceneSwitcher.LoadFailedScene();
    }

    public void LoseOneLive()
    {
        if (currentLives == 0)
        {
            StartCoroutine(DeadEnumerator());
            return;
        }
        currentLives = Mathf.Clamp(currentLives - 1, 0, _maxLives);
        _playerHealth.restoreAllHealth();
        TeleportToCHeckpoint();
        DisplayLives();
    }

    private void TeleportToCHeckpoint ()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();
        controller.enabled = false;
        transform.SetPositionAndRotation(_pointToRestore.position, _pointToRestore.rotation);
        controller.enabled = true;

        //Vector3 teleportOffset = _pointToRestore.position - gameObject.transform.position;
        //controller.Move(teleportOffset);;
    }
}
