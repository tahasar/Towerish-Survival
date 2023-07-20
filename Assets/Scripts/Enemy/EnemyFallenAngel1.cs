using NaughtyAttributes;
using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

public class EnemyFallenAngel1 : Enemy
{
    [Expandable] public EnemyBase enemyBase;
    public Animator anim;

    private void Start()
    {
        enemyTransform = gameObject.GetComponent<Transform>();
        target = GameObject.FindGameObjectsWithTag("Player");
        characterStats = target[mainTarget].GetComponent<PlayerStats>();
        deathSound = GetComponent<AudioSource>();
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        enemyName = enemyBase.enemyName;
        enemyInfo = enemyBase.enemyInfo;
        health = enemyBase.health;
        maxHealth = enemyBase.maxHealth;
        attackDamage = enemyBase.attackDamage;
        range = enemyBase.range;
        speed = enemyBase.speed;
        speedMultiplier = enemyBase.speedMultiplier;
        xpReward = enemyBase.xpReward;
        sprite = enemyBase.sprite;
        enemyTransform = GetComponent<Transform>();

        animator = anim;
    }
}