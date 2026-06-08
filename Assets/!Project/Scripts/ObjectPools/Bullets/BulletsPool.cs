using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private List<GameObject> _bullets = new List<GameObject>();

    public static BulletsPool Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void Get(Vector3 position, Quaternion rotation)
    {
        var obj = _bullets?.FirstOrDefault(x => !x.activeSelf);
        if (obj == null)
        {
            obj = CreateBullet(position, rotation);
        }
        else
        {
            obj.SetActive(true);
            obj.transform.SetPositionAndRotation(position, rotation);
            //obj.GetComponent<BulletMovement>().ChangeBulletTransform(firePoint);
            obj.GetComponent<BulletLifetime>().EnableBulletLifecycle();
        }
    }

    public void Release(GameObject obj)
    {
        obj.GetComponent<BulletLifetime>().DisableBulletLifecycle();
        obj.SetActive(false);
    }

    private GameObject CreateBullet(Vector3 position, Quaternion rotation)
    {
        var obj = Instantiate(_bulletPrefab, position, rotation, transform);
        obj.GetComponent<BulletLifetime>().EnableBulletLifecycle();
        _bullets.Add(obj);
        return obj;
    }
}
