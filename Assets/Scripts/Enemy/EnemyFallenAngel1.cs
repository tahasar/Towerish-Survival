using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFallenAngel1 : Enemy
{
    [Expandable] public EnemyBase enemyBase;
    public Animator anim;

    void Start()
    {
        enemyTransform = gameObject.GetComponent<Transform>();
        target = GameObject.FindGameObjectsWithTag("Player");
        player = target[mainTarget].GetComponent<Player>();
        deathSound = GetComponent<AudioSource>();
        enemySprite = GetComponent<SpriteRenderer>();
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
