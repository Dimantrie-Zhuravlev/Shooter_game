using TMPro;
using UnityEngine;
using System.Collections;

public class GunsController : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoesText;
    [SerializeField] private TMP_Text _clipsText;
    [SerializeField] private TMP_Text _reloadText;
    private int _currentDamage;
    private int _currentClips;
    private int _currentAmmoes;
    private int _maxClips;
    private int _maxAmmoes;
    public int CurrentDamage => _currentDamage;
    public int CurrentClips => _currentClips;
    public int CurrentAmmoes => _currentAmmoes;
    public bool AbilityEnable => abilityEnable;

    private Coroutine coroutineReload;
    private bool abilityEnable = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentDamage = GunM107Character.damage;
        _currentClips = GunM107Character.maxBulletsClip;
        _currentAmmoes = GunM107Character.maxBulletsInClip;
        _maxAmmoes = GunM107Character.maxBulletsInClip;
        _maxClips = GunM107Character.maxBulletsInClip;
        DisplayAmmoesAndClips();
    }

    public void AddClip()
    {
        _currentClips = Mathf.Clamp(_currentClips + 1, 0, _maxClips);
        if (CurrentAmmoes == 0) { Reload(); return; }
        DisplayAmmoesAndClips();
    }

    private void Reload()
    {
        if (coroutineReload == null)
        {
            coroutineReload = StartCoroutine(ReloadEnumerator());
        }
    }

    private IEnumerator ReloadEnumerator()
    {
        abilityEnable = false;
        _reloadText.text = "Reload";
        yield return new WaitForSeconds(2);
        _currentClips = Mathf.Clamp(_currentClips - 1, 0, _maxClips);
        _currentAmmoes = _maxClips;
        DisplayAmmoesAndClips();
        _reloadText.text = "";
        abilityEnable = true;
        coroutineReload = null;
    }


    public void Shoot()
    {
        if (coroutineReload == null)
        {
            _currentAmmoes = Mathf.Clamp(_currentAmmoes - 1, 0, _maxAmmoes);
            if (_currentAmmoes == 0 && _currentClips != 0)
            {
                Reload();
            }
            if (_currentAmmoes == 0 && _currentClips == 0)
            {
                abilityEnable = false;
            }
            DisplayAmmoesAndClips();
        }
    }

    private void DisplayAmmoesAndClips()
    {
        _ammoesText.text = $"Ammoes: {_currentAmmoes:D2}";
        _clipsText.text = $"Clips: {_currentClips:D2}"; ;
    }
}
