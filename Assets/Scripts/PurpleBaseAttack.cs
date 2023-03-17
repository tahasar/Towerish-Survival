using UnityEngine;

public class PurpleBaseAttack : MonoBehaviour
{
    public float speed = 0.3f;
    public float rotateSpeed = 1000f;
    public float range = 50;
    public float damage = 50;
    public Rigidbody2D rb;
    public Transform targetEnemy;
    public GameObject player;
    private Transform enemy;
    private AttackManager attackManager;
    private float xEkseni;
    SpriteRenderer spellSprite;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackManager = player.GetComponent<AttackManager>();
        Transform characterSprite = player.GetComponent<PlayerMovement>().characterSprite;
        xEkseni = characterSprite.localScale.x;

        spellSprite = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        FindClosestEnemy();
        
        if (targetEnemy != null)
        {
            enemy = targetEnemy.GetComponent<Transform>();
            Vector2 direction = (Vector2)enemy.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;

            if (xEkseni > 0) //karakter sağa bakıyorsa
            {
                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.velocity = transform.right * speed;
            }
            else if (xEkseni < 0) //karakter sola bakıyorsa
            {
                spellSprite.flipX = true;
                rb.angularVelocity = rotateAmount * rotateSpeed;
                rb.velocity = -transform.right * speed;
            }
        }
    }
    
    public void FindClosestEnemy()
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
            targetEnemy = nearestEnemy.transform;
        }
        else
        {
            targetEnemy = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        speed = 0;
        spellSprite.enabled = false;
        Destroy(gameObject, 1f);
    }
}
