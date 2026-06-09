using System.Collections;
using UnityEngine;

public class HandleObjectViewCoroutine : MonoBehaviour
{
    [SerializeField] public GameObject objectMain;

    public void ObjectStartCoroutine()
    {
        StartCoroutine(ObjectRenew());
    }
    public IEnumerator ObjectRenew()
    {
        yield return new WaitForSeconds(5);
        objectMain.SetActive(true);
        gameObject.SetActive(false);
    }
}
