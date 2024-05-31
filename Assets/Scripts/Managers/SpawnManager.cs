using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PoolManager poolManager;
    
    public List<EnemyProbablity> enemies;
    
    private void Start()
    {
        poolManager = PoolManager.Instance;
        
        foreach (var enemy in enemies)
        {
            poolManager.CreatePool(transform, enemy.enemy, enemy.count);
        }
    }
    
    public void SpawnEnemy()
    {
        float random = Random.Range(0f, 1f);
        
        foreach (var enemy in enemies)
        {
            if (random <= enemy.probability)
            {
                GameObject obj = poolManager.Get(transform);
                obj.SetActive(true);
                break;
            }
            else
            {
                random -= enemy.probability;
            }
        }
    }
}
