using UnityEngine;

public class GunsController : MonoBehaviour
{
    private int _currentDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentDamage = GunM107Character.damage;
    }

    public void Shoot()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
