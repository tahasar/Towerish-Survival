using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

public class EnemyFallenAngel1 : Enemy.Enemy
{
    [Expandable] public EnemyBase enemyBase;
    public Animator anim;

    private void Start()
    {
        EnemyTransform = gameObject.GetComponent<Transform>();
        target = GameObject.FindGameObjectsWithTag("Player");
        player = target[MainTarget].GetComponent<Player.Player>();
        DeathSound = GetComponent<AudioSource>();
        EnemySprite = gameObject.GetComponent<SpriteRenderer>();
        Collider2D = GetComponent<Collider2D>();
        EnemyName = enemyBase.enemyName;
        EnemyInfo = enemyBase.enemyInfo;
        Health = enemyBase.health;
        MaxHealth = enemyBase.maxHealth;
        AttackDamage = enemyBase.attackDamage;
        Range = enemyBase.range;
        Speed = enemyBase.speed;
        SpeedMultiplier = enemyBase.speedMultiplier;
        XpReward = enemyBase.xpReward;
        Sprite = enemyBase.sprite;
        EnemyTransform = GetComponent<Transform>();

        Animator = anim;
    }
}