using System.Collections;
using UnityEngine;

public class ChangePlayerMaterial : MonoBehaviour
{
    [SerializeField] private Material matDefault; // Обычный материал
    [SerializeField] private Material matDamaged; // Материал для эффекта получения урона

    private Coroutine _changeCoroutine;

    private Renderer playerRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void ChangeMaterial()
    {
        if (_changeCoroutine == null)
        {
            _changeCoroutine = StartCoroutine(changeMaterial());
        }

    }
    private IEnumerator changeMaterial()
    {
        playerRenderer.material = matDamaged;
        yield return new WaitForSeconds(2);
        playerRenderer.material = matDefault;
        _changeCoroutine = null;
    }

}
