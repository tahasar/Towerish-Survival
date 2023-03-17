using System.Net.Mime;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public Transform sprite;
    public Vector3 enemyPosition;
    public Transform targetEnemy;
    public GameObject[] enemies;
    public Transform target;


    private void Start()
    {
        InvokeRepeating("FindClosestEnemy",0f,0.2f);
    }
    
    private void Update()
    {
        
        
        lookEnemy();
        if (targetEnemy == null)
        {
            return;
        }
    }
    
    public Transform FindClosestEnemy(float range)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        
        
        if (nearestEnemy != null && shortestDistance <= range)
        {
            return targetEnemy = nearestEnemy.transform;
        }
        else
        {
            return targetEnemy = null;
        }
    }

    void lookEnemy()
    {
        GetInstanceID();
        if (targetEnemy)
        {
            enemyPosition = targetEnemy.GetComponent<Transform>().position;
        }

        if (enemyPosition.x > sprite.position.x)
        {
            sprite.localScale = new Vector2(0.35f, sprite.localScale.y);
        }
        else
        {
            sprite.localScale = new Vector2(-0.35f, sprite.localScale.y);
        }
    }
}
