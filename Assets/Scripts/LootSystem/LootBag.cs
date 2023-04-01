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
        
        // Item'in oluşumunu sağlar.
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
}

