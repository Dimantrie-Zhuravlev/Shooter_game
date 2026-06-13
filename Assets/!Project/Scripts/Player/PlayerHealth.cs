using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private PlayerLives _playerLives;


    private float intervaleTakeDamage = 0.5f;
    private float intervaleTakeHealth = 0.5f;
    private int currentHealth;
    private Coroutine periodicalDamage;
    private Coroutine periodicalHealth;

    void Start()
    {
        restoreAllHealth();
    }

    private void DisplayHealth()
    {
        _healthText.text = $"Health: {currentHealth:D3}";
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, _maxHealth);
        if (currentHealth ==0)
        {
            _playerLives.LoseOneLive();
            return;
        }
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
            currentHealth = Mathf.Clamp(currentHealth - damagePerInterval, 0, _maxHealth);
            if (currentHealth == 0)
            {
                _playerLives.LoseOneLive();
                return;
            }
            DisplayHealth();
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
        periodicalDamage = null;
    }

    private IEnumerator PeriodicalTakeHealth(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, _maxHealth);
        DisplayHealth();
        yield return new WaitForSeconds(intervaleTakeHealth);
        periodicalHealth = null;
    }

    public void restoreAllHealth()
    {
        currentHealth = _maxHealth;
        DisplayHealth();
    }
}
