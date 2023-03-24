using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class EnemyProbabilities
{
    public string Name;

    public GameObject Prefab;
    [Range(0f, 100f)] public float chance = 100;

    [HideInInspector] public double _weight;
}

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private EnemyProbabilities[] enemies;

    [SerializeField] private bool isNight = true;
    
    private double accumulatedWeights;
    private System.Random rand = new System.Random();

    private void Awake()
    {
        CalculateWeights();
    }

    private void Start()
    {
        if (isNight)
        {
            InvokeRepeating("SpawnRandomEnemy",5f,2f);
        }
    }

    private void SpawnRandomEnemy()
    {
        EnemyProbabilities randomEnemy = enemies[GetRandomEnemyIndex()];

        Instantiate(randomEnemy.Prefab, new Vector2(Random.Range(-20,20f),Random.Range(-20f,20f)), Quaternion.identity, transform);
    }

    private int GetRandomEnemyIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i]._weight >= r)
                return i;
        }

        return 0;
    }

    private void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach (EnemyProbabilities enemy in enemies)
        {
            accumulatedWeights += enemy.chance;
            enemy._weight = accumulatedWeights;
        }
    }
}
