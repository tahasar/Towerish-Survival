using System;
using NaughtyAttributes;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [Header("Hedefler")]
    public GameObject[] target; // Oyuncu karakteri
    public Player player;
    
    protected float health;
    protected float xpReward;
    protected float range;
    protected float attackDamage;
    protected Animator animator;
    protected string enemyName;
    protected string enemyInfo;
    protected float maxHealth;
    protected float speed;
    protected float speedMultiplier = 1;
    protected Sprite sprite;
    protected Transform enemyTransform;
    protected bool isFlipped;
    protected bool inRange;
    protected bool isDead = false;
    protected int mainTarget;
    protected Vector2 movement;
    protected float kuleMesafesi;
    protected float adamMesafesi;
    protected AudioSource deathSound;
    protected SpriteRenderer enemySprite;
    protected Collider2D collider2D;

    public bool isAttacking;
    public Vector2 damageTextLocation;
    public GameObject damageText;

    public DropOnDestroy dropOnDestroy;
    public GameObject explotionEffect;

    public void Update()
    {
        ChooseTarget();

        TargetDetect(); // Hedef takibini sağlar.

        GetTargetDistance(); // Hedef ile düşman arasındaki mesafeyi ölçer.

        LookAtTarget(); // Düşmanın yönünü hedefe çevirir.
        
        if(!isAttacking)
        {
            Move(movement);
        }

        if (isDead)
        {
            player.GetComponent<Level>().AddExperience(xpReward);
            Instantiate(explotionEffect, enemyTransform.position, quaternion.identity);
            deathSound.Play();
            dropOnDestroy.Drop();
            Destroy(gameObject, 0.15f);
            isDead = false;
        }
    }

    private void GetTargetDistance()        // Hedef ile düşman arasındaki mesafeyi ölçer.
    {
        inRange = Vector2.Distance(target[mainTarget].transform.position, enemyTransform.position) <= range;
    }

    private void TargetDetect()        // Hedef takibini sağlar.
    {
        Vector3 direction = target[mainTarget].transform.position - enemyTransform.position;
        direction.Normalize();
        movement = direction;
    }

    public virtual void ChooseTarget()
    {
        kuleMesafesi = Vector2.Distance(target[1].transform.position, enemyTransform.position);

        adamMesafesi = Vector2.Distance(target[0].transform.position, enemyTransform.position);

        if (kuleMesafesi > adamMesafesi)
        {
            mainTarget = 0;
        }
        else
        {
            mainTarget = 1;
        }
    }

    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        
        if (health <= 0)
        {
            Destroy(enemySprite);
            collider2D.enabled = false;
            isDead = true;
        }
    }

    public void Attack()
    {
        if(inRange)
        {
            player.TakeDamage(attackDamage);
        }
    }

    public void LookAtTarget()
    {
        Vector3 flipped = transform.localScale;
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
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            enemyTransform.position = ((Vector2)enemyTransform.position + (direction * (speed * Time.deltaTime)));
        }
    }
}
