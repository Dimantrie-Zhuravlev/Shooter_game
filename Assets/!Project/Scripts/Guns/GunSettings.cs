using UnityEngine;

[CreateAssetMenu]
public class GunSettings : ScriptableObject, IGunCharacter
{
    public int damage = 10;
    public int maxBulletsInClip = 5;
    public int maxBulletsClip = 4;

    int IGunCharacter.damage => damage;
    int IGunCharacter.maxBulletsInClip => maxBulletsInClip;
    int IGunCharacter.maxBulletsClip => maxBulletsClip;
}

public class GunSettingsBehaviour: IGunCharacter
{
    public int damage = 10;
    public int maxBulletsInClip = 100;
    public int maxBulletsClip = 100;

    int IGunCharacter.damage => damage;
    int IGunCharacter.maxBulletsInClip => maxBulletsInClip;
    int IGunCharacter.maxBulletsClip => maxBulletsClip;
}