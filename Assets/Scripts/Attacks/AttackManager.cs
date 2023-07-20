using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public Transform sprite;
    public Vector3 enemyPosition;
    public Transform targetEnemy;
    public GameObject[] enemies;
    public Transform target;

    private void Update()
    {
        if (targetEnemy != null) lookEnemy();
    }

    public Transform FindClosestEnemy(float range)
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }


        if (nearestEnemy != null && shortestDistance <= range)
            return targetEnemy = nearestEnemy.transform;
        return targetEnemy = null;
    }

    private void lookEnemy()
    {
        FindClosestEnemy(float.MaxValue);
        if (targetEnemy) enemyPosition = targetEnemy.GetComponent<Transform>().position;

        if (enemyPosition.x > sprite.position.x)
            sprite.localScale = new Vector2(0.35f, sprite.localScale.y);
        else
            sprite.localScale = new Vector2(-0.35f, sprite.localScale.y);
    }
}