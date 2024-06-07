using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public Item item;

    public Image icon;

    public void SetItem(Item item)
    {
        this.item = item;
        icon.sprite = item.icon;
    }
}
