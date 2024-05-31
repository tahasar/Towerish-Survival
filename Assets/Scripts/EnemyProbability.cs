using System;
using UnityEngine;

[Serializable]
public class EnemyProbablity
{ 
    public GameObject enemy;
    
    [Range(0, 1)]
    public float probability;
    
    public int count;

    public EnemyProbablity(float probability, GameObject enemy, int count)
    {
        this.probability = probability;
        this.enemy = enemy;
        this.count = count;
    }
}
