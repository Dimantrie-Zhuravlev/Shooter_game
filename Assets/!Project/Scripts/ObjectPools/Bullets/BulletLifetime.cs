using UnityEngine;
using System.Collections;

public class BulletLifetime : MonoBehaviour
{
    private BulletsPool _bulletPool;
    private Coroutine _coroutineLifecycle;
    [SerializeField] private float _lifetime = 6f;
    void Start()
    {
        _bulletPool = BulletsPool.Instance;
        EnableBulletLifecycle();
    }
    public void EnableBulletLifecycle()
    {
        if (_coroutineLifecycle == null)
        {
            _coroutineLifecycle = StartCoroutine(EnableLifecycleCoroutine());
        }
        else
        {
            StopAllCoroutines();
            _coroutineLifecycle = StartCoroutine(EnableLifecycleCoroutine());
        }
    }
    /// <summary>
    /// очистка ЖЦ
    /// </summary>
    public void DisableBulletLifecycle()
    {
        _coroutineLifecycle = null;
        StopAllCoroutines();
    }

    public IEnumerator EnableLifecycleCoroutine()
    {
        yield return new WaitForSeconds(_lifetime);
        _bulletPool.Release(gameObject);
    }
}
