using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public GameObject player;
    public Level level;
    public CharacterStats characterStatsScript;
    public GameObject enemyManager;
    public WeightedRandomList weightedRandomList;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        level = player.GetComponent<Level>();
        characterStatsScript = player.GetComponent<CharacterStats>();
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");
        weightedRandomList = enemyManager.GetComponent<WeightedRandomList>();
    }

    public void InstantiateLoot(Vector2 spawnPosition)
    {
        
        // Item'in oluşumunu sağlar.
        LootProbabilities item = weightedRandomList.SpawnRandomLoot();
        Loot loot = item.loot;

        GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, quaternion.identity);
        
        
        // Item'in özelliklerini ScriptableObject üzerinden çeker.
        SpriteRenderer itemSprite = lootGameObject.GetComponent<SpriteRenderer>();
        itemSprite.sprite = loot.lootSprite;
        itemSprite.color = loot.color;

        Collectable collectable = lootGameObject.GetComponent<Collectable>();

        collectable.level = level;
        collectable.characterStats = characterStatsScript;
        
        if (loot.lootType == "XP") //Eğer obje türü XP ise,
        {
            lootGameObject.name = $"XP ({loot.xpAmount})";
            collectable.lootType = loot.lootType;
            collectable.xpAmount = loot.xpAmount;
        }
        else if (loot.lootType == "HEAL")
        {
            lootGameObject.name = $"Heal ({loot.healAmount})";
            collectable.lootType = loot.lootType;
            collectable.healAmount = loot.healAmount;
        }


        // Item'in oluşumundan sonra rastgele bi yöne saçılmasını sağlar.
        float dropForce = 300f;
        Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
    }
}

