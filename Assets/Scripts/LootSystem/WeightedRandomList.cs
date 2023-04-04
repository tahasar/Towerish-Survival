using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]
public class LootProbabilities
{
    [Range(0f, 100f)] public float chance = 100;

    [HideInInspector] public double _weight;

    public Loot loot;
}

public class WeightedRandomList : MonoBehaviour
{
    
    [SerializeField] private LootProbabilities[] loots;
    
    private float accumulatedWeights;
    private System.Random rand = new System.Random();

    private void Awake()
    {
        CalculateWeights();
    }

    public LootProbabilities SpawnRandomLoot()
    {
        LootProbabilities randomLoot = loots[GetRandomLootIndex()];

        return randomLoot;
    }

    private int GetRandomLootIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for (int i = 0; i < loots.Length; i++)
        {
            if (loots[i].chance >= r)
                return i;
        }

        return 0;
    }

    private void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach (LootProbabilities loot in loots)
        {
            accumulatedWeights += loot.chance;
            loot.chance = accumulatedWeights;
        }
    }
}

//[System.Serializable]
//public class WeightedRandomList<T>
//{
//    public List<Loot> list = new List<Loot>();
//
//    public Loot GetRandomItem()
//    {
//        float totalWeight = 0;
//
//        foreach (Loot item in list)
//        {
//            totalWeight += item.dropChance;
//        }
//
//        float value = Random.value * totalWeight;
//
//        float sumWeight = 0;
//
//        foreach (Loot item in list)
//        {
//            sumWeight += item.dropChance;
//
//            if (sumWeight >= value)
//            {
//                return item;
//            }
//        }
//
//        return null;
//    }
//}