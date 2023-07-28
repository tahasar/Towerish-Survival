using System;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
    [Serializable]
    public class EnemyProbabilities
    {
        public string Name;

        public GameObject Prefab;
        [Range(0f, 100f)] public float chance = 100;

        [HideInInspector] public double _weight; //
    }

    public class EnemySpawnManager : MonoBehaviour
    {
        public float spawnTime;

        [SerializeField] private EnemyProbabilities[] enemies;

        [SerializeField] private bool isNight = true;

        [SerializeField] private Vector2 spawnArea;

        private double accumulatedWeights;
        private GameObject player;
        private readonly Random rand = new();

        private void Awake()
        {
            CalculateWeights();
        }

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (isNight) InvokeRepeating("SpawnRandomEnemy", 2, spawnTime);
        }

        private void SpawnRandomEnemy()
        {
            var randomEnemy = enemies[GetRandomEnemyIndex()];

            Instantiate(randomEnemy.Prefab, GenerateRandomPosition(), Quaternion.identity, transform);
        }

        private Vector2 GenerateRandomPosition()
        {
            var position = new Vector2();

            var f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
            if (UnityEngine.Random.value > 0.5f)
            {
                position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
                position.y = spawnArea.y * f;
            }
            else
            {
                position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
                position.x = spawnArea.x * f;
            }

            position += (Vector2)player.transform.position;

            return position;
        }

        private int GetRandomEnemyIndex()
        {
            var r = rand.NextDouble() * accumulatedWeights;

            for (var i = 0; i < enemies.Length; i++)
                if (enemies[i]._weight >= r)
                    return i;

            return 0;
        }

        private void CalculateWeights()
        {
            accumulatedWeights = 0f;
            foreach (var enemy in enemies)
            {
                accumulatedWeights += enemy.chance;
                enemy._weight = accumulatedWeights;
            }
        }
    }
}