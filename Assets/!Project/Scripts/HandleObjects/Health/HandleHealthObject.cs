using System.Collections;
using UnityEngine;

public class HandleHealthObject : AbstractHandleObject
{
    [SerializeField] public bool isRenewable;
    [SerializeField] public int health;
    [SerializeField] public HandleObjectViewCoroutine objectView;
    [SerializeField] public GameObject _marker;

    public override void OnEnterObject() {}

    public void Start()
    {
        _marker.SetActive(isRenewable);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null)
        {
            player.TakeHealth(health);
            if (isRenewable)
            {
                objectView.gameObject.SetActive(true);
                objectView.ObjectStartCoroutine();
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}