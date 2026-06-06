using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; set; }

    private void Start()
    {
        Instance = this;
    }


}
