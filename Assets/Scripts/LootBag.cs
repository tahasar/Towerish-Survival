using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootBag : MonoBehaviour
{
    public WeightedRandomList<Loot> list;
    public GameObject droppedItemPrefab;
    public GameObject player;
    public Level level;
    public Player playerScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        level = player.GetComponent<Level>();
        playerScript = player.GetComponent<Player>();
    }

    public void InstantiateLoot(Vector2 spawnPosition)
    {
        
        // Item'in oluşumnu sağlar.
        Loot item = list.GetRandomItem();
        GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, quaternion.identity);
        
        
        // Item'in özelliklerini ScriptableObject üzerinden çeker.
        SpriteRenderer itemSprite = lootGameObject.GetComponent<SpriteRenderer>();
        itemSprite.sprite = item.lootSprite;
        itemSprite.color = item.color;
        
        lootGameObject.name = item.name;

        Collectable collectable = lootGameObject.GetComponent<Collectable>();

        collectable.level = level;
        collectable.player = playerScript;
        
        if (item.lootType == "XP") //Eğer obje türü XP ise,
        {
            collectable.lootType = item.lootType;
            collectable.xpAmount = item.xpAmount;
        }
        else if (item.lootType == "HEAL")
        {
            
            collectable.lootType = item.lootType;
            collectable.healAmount = item.healAmount;
        }


        // Item'in oluşumundan sonra rastgele bi yöne saçılmasını sağlar.
        float dropForce = 300f;
        Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
    }
    
    //public List<Loot> lootList = new List<Loot>();
//
    //Loot GetDroppedItem()
    //{
    //    int randomNumber = Random.Range(1, 101); //1-100
    //    List<Loot> possibleItems = new List<Loot>();
    //    foreach (Loot item in lootList)
    //    {
    //        if (randomNumber <= item.dropChance)
    //        {
    //            possibleItems.Add(item);
    //        }
    //    }
//
    //    if (possibleItems.Count > 0)
    //    {
    //        Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
    //        return droppedItem;
    //            
    //    }
    //    Debug.Log("No loot dropped.");
    //    return null;
    //}
//
}

