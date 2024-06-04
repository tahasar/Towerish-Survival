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
    
    public GameEvent onEnemyDied;
    private Transform _transform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = transform;
        targetManager = TargetManager.Instance;
        
        target = targetManager.GetClosestTarget(transform, targetTags.ToList());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }

    private void FixedUpdate()
    {
        GetClosestTarget();
    }
    
    private void GetClosestTarget()
    {
        target = targetManager.GetClosestTarget(transform, targetTags.ToList());
    }

    void MoveTowardsTarget()
    {
        // Move towards the target
        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        // If the enemy reaches the target
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Die();
        }
    }
    
    private void Die()
    {
        onEnemyDied.TriggerEvent(_transform, _transform);
        //gameObject.SetActive(false);
    }

    void ReachTarget()
    {
        // 
    }
}