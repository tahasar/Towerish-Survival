using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public int value;
    public Sprite icon;
}
