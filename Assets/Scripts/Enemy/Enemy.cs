using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Hedefler")] public GameObject[] target; // Oyuncu karakteri

    public Stats player;

    public bool isAttacking;
    public Vector2 damageTextLocation;
    public GameObject damageText;

    public DropOnDestroy dropOnDestroy;
    public GameObject explotionEffect;
    protected float adamMesafesi;
    protected Animator animator;
    protected float attackDamage;
    protected Collider2D collider2D;
    protected AudioSource deathSound;
    protected string enemyInfo;
    protected string enemyName;
    protected SpriteRenderer enemySprite;
    protected Transform enemyTransform;

    protected float health;
    protected bool inRange;
    protected bool isDead;
    protected bool isFlipped;
    protected float kuleMesafesi;
    protected int mainTarget;
    protected float maxHealth;
    protected Vector2 movement;
    protected float range;
    protected float speed;
    protected float speedMultiplier = 1;
    protected Sprite sprite;
    protected float xpReward;

    private void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }

    public void Update()
    {
        ChooseTarget();

        TargetDetect(); // Hedef takibini sağlar.

        GetTargetDistance(); // Hedef ile düşman arasındaki mesafeyi ölçer.

        LookAtTarget(); // Düşmanın yönünü hedefe çevirir.

        if (!isAttacking) Move(movement);

        if (isDead)
        {
            player.GetComponent<Level>().AddExperience(xpReward);
            Instantiate(explotionEffect, enemyTransform.position, quaternion.identity);
            dropOnDestroy.Drop();
            Destroy(gameObject, 0.12f);
            isDead = false;
        }
    }

    private void GetTargetDistance() // Hedef ile düşman arasındaki mesafeyi ölçer.
    {
        inRange = Vector2.Distance(target[mainTarget].transform.position, enemyTransform.position) <= range;
    }

    private void TargetDetect() // Hedef takibini sağlar.
    {
        var direction = target[mainTarget].transform.position - enemyTransform.position;
        direction.Normalize();
        movement = direction;
    }

    public virtual void ChooseTarget()
    {
        kuleMesafesi = Vector2.Distance(target[1].transform.position, enemyTransform.position);

        adamMesafesi = Vector2.Distance(target[0].transform.position, enemyTransform.position);

        if (kuleMesafesi > adamMesafesi)
            mainTarget = 0;
        else
            mainTarget = 1;
    }

    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(enemySprite);
            deathSound.Play();
            collider2D.enabled = false;
            isDead = true;
        }
    }

    public void Attack()
    {
        if (inRange) player.TakeDamage(attackDamage);
    }
    public void LookAtTarget()
    {
        var flipped = transform.localScale;
        flipped.z *= -1f;

        if (enemyTransform.position.x < target[mainTarget].transform.position.x && isFlipped)
        {
            enemyTransform.localScale = flipped;
            enemyTransform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (enemyTransform.position.x > target[mainTarget].transform.position.x && !isFlipped)
        {
            enemyTransform.localScale = flipped;
            enemyTransform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Move(Vector2 direction) // Hedef menzilde(inRange) değilse hareket eder.
    {
        if (inRange)
            animator.SetTrigger("Attack");
        else
            enemyTransform.position = (Vector2)enemyTransform.position + direction * (speed * Time.deltaTime);
    }
}