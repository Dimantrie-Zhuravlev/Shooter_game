using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private TMP_Text _healthText;

    private float intervaleTakeDamage = 0.5f;
    private float intervaleTakeHealth = 0.5f;
    private int currentHealth;
    private Coroutine periodicalDamage;
    private Coroutine periodicalHealth;

    void Start()
    {
        currentHealth = _maxHealth;
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        _healthText.text = $"Health: {currentHealth:D3}";
    }

    public void TakeDamage(int damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, _maxHealth);
        DisplayHealth();
    }

    public void TakeHealth(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, _maxHealth);
        DisplayHealth();
    }
    public void TakePeriodicalDamage(int damagePerInterval)
    {
        if (periodicalDamage == null)
        {
            periodicalDamage = StartCoroutine(PeriodicalTakeDamage(damagePerInterval));
        }
    }

    public void TakePeriodicalHealth(int damagePerInterval)
    {
        if (periodicalHealth == null)
        {
            periodicalHealth = StartCoroutine(PeriodicalTakeHealth(damagePerInterval));
        }
    }

    private IEnumerator PeriodicalTakeDamage(int damage)
    {
        yield return new WaitForSeconds(intervaleTakeDamage);
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, _maxHealth);
        DisplayHealth();
        periodicalDamage = null;
    }

    private IEnumerator PeriodicalTakeHealth(int health)
    {
        yield return new WaitForSeconds(intervaleTakeHealth);
        currentHealth = Mathf.Clamp(currentHealth + health, 0, _maxHealth);
        DisplayHealth();
        periodicalDamage = null;
    }
}
