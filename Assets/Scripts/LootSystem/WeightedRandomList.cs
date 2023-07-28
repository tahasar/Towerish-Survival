using System;
using UnityEngine;
using Random = System.Random;

namespace LootSystem
{
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
        private readonly Random rand = new();

        private void Awake()
        {
            CalculateWeights();
        }

        public LootProbabilities SpawnRandomLoot()
        {
            var randomLoot = loots[GetRandomLootIndex()];

            return randomLoot;
        }

        private int GetRandomLootIndex()
        {
            var r = rand.NextDouble() * accumulatedWeights;

            for (var i = 0; i < loots.Length; i++)
                if (loots[i].chance >= r)
                    return i;

            return 0;
        }

        private void CalculateWeights()
        {
            accumulatedWeights = 0f;
            foreach (var loot in loots)
            {
                accumulatedWeights += loot.chance;
                loot.chance = accumulatedWeights;
            }
        }
    }
}