using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;
    private TargetManager targetManager;
    
    [Tag]
    public string[] targetTags; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetManager = FindObjectOfType<TargetManager>();
        target = targetManager.GetTarget(gameObject, targetTags.ToList());
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
        else
        {
            target = targetManager.GetTarget(gameObject, targetTags.ToList());
        }
    }

    void MoveTowardsTarget()
    {
        // Move towards the target
        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        // If the enemy reaches the target
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            ReachTarget();
        }
    }

    void ReachTarget()
    {
        // Implement the action when the enemy reaches the target
        // This could be damaging the target, destroying the enemy itself, etc.
        // For now, let's just destroy the enemy itself
        Destroy(gameObject);
    }
}