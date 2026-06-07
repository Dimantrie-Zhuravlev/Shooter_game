using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] Image _healthBar;

    [SerializeField] public Transform healthContainer;
    [SerializeField] public float containerHeight;

    private float currentHealth;

    void Start()
    {
        currentHealth = _maxHealth;
        healthContainer.position = new Vector3(transform.position.x, transform.position.y + containerHeight, transform.position.z);
        DisplayHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            currentHealth = Mathf.Clamp(currentHealth - 25f, 0, _maxHealth);
            DisplayHealth();
        }
    }
    private void Update()
    {
        healthContainer.position = new Vector3(transform.position.x, transform.position.y + containerHeight, transform.position.z);
    }

    private void DisplayHealth()
    {
        _healthBar.fillAmount = currentHealth / _maxHealth;
    }
}
