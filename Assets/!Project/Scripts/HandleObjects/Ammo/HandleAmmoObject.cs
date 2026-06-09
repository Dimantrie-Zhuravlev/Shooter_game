using UnityEngine;

public class HandleAmmoObject : AbstractHandleObject
{
    [SerializeField] public bool isRenewable;
    [SerializeField] public HandleObjectViewCoroutine objectView;
    [SerializeField] public GameObject _marker;
    [SerializeField] public GunsController _gunsController;
    

    public override void OnEnterObject() { }

    public void Start()
    {
        _marker.SetActive(isRenewable);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            _gunsController.AddClip();
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
