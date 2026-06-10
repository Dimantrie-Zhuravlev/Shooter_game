using UnityEngine;

public interface IGunCharacter
{
    int damage { get; }
    int maxBulletsInClip { get; }
    int maxBulletsClip { get; }
}
