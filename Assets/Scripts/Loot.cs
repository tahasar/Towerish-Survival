using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    private string lootName;
    public float dropChance;
    [Space]
    public Sprite lootSprite;
    public Color color;
    [Space]
    public string lootType;
    public float xpAmount;
    public float healAmount;
}
