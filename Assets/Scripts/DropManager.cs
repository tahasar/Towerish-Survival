using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab;
    
    public List<DropItem> dropItems; // The list of possible items that can be dropped

    public void DropItem(Transform enemy, object data)
    {
        int totalDropChance = 0;
        foreach (var dropItem in dropItems)
        {
            totalDropChance += dropItem.dropChance;
        }

        int randomChance = Random.Range(0, totalDropChance);
        int cumulativeChance = 0;

        foreach (var dropItem in dropItems)
        {
            cumulativeChance += dropItem.dropChance;
            if (randomChance <= cumulativeChance)
            {
                if (dropItem.item != null)
                {
                    GameObject droppedItem = Instantiate(itemPrefab, enemy.position, Quaternion.identity);
                    droppedItem.GetComponent<ItemInfo>().SetItem(dropItem.item);
                    break;
                }
            }
        }
    }
}

[System.Serializable]
public class DropItem
{
    public Item item; // The item that will be dropped
    
    [Range(0, 100)]
    public int dropChance; // The chance that this item will be dropped
}