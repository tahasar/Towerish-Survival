using NaughtyAttributes;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Expandable] public EnemyBase enemyBase;
    public float health;
    
    [Header("Hedefler")]
    public GameObject[] target; // Oyuncu karakteri
    public Player player;
    public DropOnDestroy dropOnDestroy;

    public Animator animator;
    public float xpReward;
    
    public bool isAttacking;
    
    private bool isFlipped;
    private bool inRange;
    private bool isDead = false;
    private int mainTarget;
    private Vector2 movement;
    private float kuleMesafesi;
    private float adamMesafesi;
    public GameObject explotionEffect;
    private AudioSource deathSound;
    private SpriteRenderer enemySprite;
    private new Collider2D collider2D; // bir sorun çıkarsa "new" kaldır.

    private Vector2 damageTextLocation;
    public GameObject damageText;

    private void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player");
        health = enemyBase.health;
        xpReward = enemyBase.xpReward;
        player = target[mainTarget].GetComponent<Player>();
        deathSound = GetComponent<AudioSource>();
        enemySprite = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }
    
    public void FixedUpdate()
    {

        ChooseTarget();

        // Hedef takibini sağlar.
        Vector3 direction = target[mainTarget].transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;

        // Hedef ile düşman arasındaki mesafeyi ölçer.
        inRange = Vector2.Distance(target[mainTarget].transform.position, transform.position) <= enemyBase.range;
        
        LookAtTarget(); // Düşmanın yönünü hedefe çevirir.
        
        if(!isAttacking)
        {
            MoveCharacter(movement);
        }

        if (isDead)
        {
            player.GetComponent<Level>().AddExperience(xpReward);
            Instantiate(explotionEffect, transform.position, quaternion.identity);
            deathSound.Play();
            dropOnDestroy.Drop();
            Destroy(gameObject, 0.15f);
            isDead = false;
        }
    }
    
    void ChooseTarget()
    {
        kuleMesafesi = Vector2.Distance(target[1].transform.position, transform.position);

        adamMesafesi = Vector2.Distance(target[0].transform.position, transform.position);

        if (kuleMesafesi > adamMesafesi)
        {
            mainTarget = 0;
        }
        else
        {
            mainTarget = 1;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        
        if (health <= 0)
        {
            Destroy(enemySprite);
            Destroy(collider2D);
            isDead = true;
        }
    }

    public void Attack()
    {
        if(inRange)
        {
            player.TakeDamage(enemyBase.attackDamage);
        }
    }

    public void LookAtTarget()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < target[mainTarget].transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > target[mainTarget].transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void MoveCharacter(Vector2 direction) // Hedef menzilde(inRange) değilse hareket eder.
    {
        if (inRange)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            transform.position = ((Vector2)transform.position + (direction * (enemyBase.speed * Time.deltaTime)));
        }
    }
}
