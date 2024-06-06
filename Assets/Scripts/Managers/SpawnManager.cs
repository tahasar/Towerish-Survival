using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    private void Awake() => Instance = this;

    private PoolManager poolManager;
    
    public static List<Transform> activeEnemies = new List<Transform>(); // active enemies list
    public List<EnemyProbablity> enemies;
    
    public Vector2 centerPoint;
    public float spawnDistance, spawnRate;
    public double _totalWeights;
    
    private void Start()
    {
        poolManager = PoolManager.Instance;
        
        foreach (var enemy in enemies)
        {
            poolManager.CreatePool(enemy.enemy, enemy.poolSize);
        }

        InvokeRepeating(nameof(SpawnEnemy), 2, spawnRate);
    }
    
    void SpawnEnemy()
    {
        CalculateWeights();

        double randomWeight = Random.Range(0, (float)_totalWeights);
        EnemyProbablity enemyToSpawn = FindEnemyBasedOnWeight(randomWeight);

        if (enemyToSpawn != null)
        {
            Vector2 spawnPosition = centerPoint + Random.insideUnitCircle.normalized * spawnDistance;
            Transform enemy = poolManager.GetObjectFromPool(enemyToSpawn.enemy);
            
            if (enemy != null)
            {
                enemy.transform.position = spawnPosition;
                enemy.gameObject.name = enemyToSpawn.enemy.name;
                
                EnemySpawned(enemy);
            }
        }
    }
    
    public void EnemySpawned(Transform enemy)
    {
        activeEnemies.Add(enemy); // add the enemy to the list
    }
    
    public void EnemyDied(Transform sender, object data)
    {
        var enemy = data as Transform;
        activeEnemies.Remove(sender);
        poolManager.ReturnObjectToPool(sender.name, enemy);
    }
    
    private EnemyProbablity FindEnemyBasedOnWeight(double weight)
    {
        foreach (var enemy in enemies)
        {
            if (enemy.cumulativeWeight >= weight)
            {
                return enemy;
            }
        }

        return null;
    }

    public void CalculateWeights()
    {
        _totalWeights = 0f;
        foreach (var enemy in enemies)
        {
            _totalWeights += enemy.probability;
            enemy.cumulativeWeight = _totalWeights;
        }
    }
}

[System.Serializable]
public class EnemyProbablity
{
    public Transform enemy;
    public int poolSize;
    
    [Range(0,100)]
    public int probability;
    
    [HideInInspector]
    public double cumulativeWeight;
}
