using System.Collections.Generic;
using UnityEngine;

public class ButtonSpidersCreate : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spidersList = new List<GameObject>();
    [SerializeField] private List<Transform> _spidersCreatePoints = new List<Transform>();
    public void CreateSpiders()
    {
        bool isAnyActive = false;

        foreach (GameObject obj in _spidersList)
        {
            if (obj.activeSelf)
            {
                isAnyActive = true;
                break;
            }
        }

        if (!isAnyActive)
        {
            for (int i = 0; i < _spidersList.Count; i++)
            {
                GameObject currentObj = _spidersList[i];
                currentObj.transform.position = _spidersCreatePoints[i].position;
                currentObj.GetComponent<EnemyHealth>().RestoreHealth();
                currentObj.SetActive(true);
            }
        }
    }
}
