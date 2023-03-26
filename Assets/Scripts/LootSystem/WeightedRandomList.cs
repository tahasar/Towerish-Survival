using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeightedRandomList<T>
{
    public List<Loot> list = new List<Loot>();
    
    //[System.Serializable]
    //public struct Loot
    //{
    //    public string lootName;
    //    public float dropChance;
//
    //    public Loot(string lootName, float dropChance)
    //    {
    //        this.lootName = lootName;
    //        this.dropChance = dropChance;
    //    }
    //}
//
    //public int Count
    //{
    //    get => list.Count;
    //}
//
    //public void Add(string lootName, float dropChance)
    //{
    //    list.Add(new Loot(lootName, dropChance));
    //}

    public Loot GetRandomItem()
    {
        float totalWeight = 0;

        foreach (Loot item in list)
        {
            totalWeight += item.dropChance;
        }

        float value = Random.value * totalWeight;

        float sumWeight = 0;

        foreach (Loot item in list)
        {
            sumWeight += item.dropChance;

            if (sumWeight >= value)
            {
                return item;
            }
        }

        return null;
    }
}