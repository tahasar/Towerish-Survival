using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    public new string name = "New Item";
    public string itemType;
    public Sprite icon;
    public bool isStackable;
}