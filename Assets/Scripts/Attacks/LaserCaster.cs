using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

public class LaserCaster : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private AttackManager attackManager;
    private LineRenderer lineRenderer;
    
    private Transform targetEnemy;
    private Transform enemy;
    private bool canDamage = true;
    
    [HorizontalGroup("Split", Width = 50), HideLabel, PreviewField(50)]
    public Texture2D Icon;
    
    [VerticalGroup("Split/Properties")]
    public float range = 5;
    [VerticalGroup("Split/Properties")]
    public float damage = 50;
    [VerticalGroup("Split/Properties")]
    public float damageTime = 0.5f;

    
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        attackManager = player.GetComponent<AttackManager>();
    }

    // Update is called once per frame
    void Update()
    {
        targetEnemy = attackManager.FindClosestEnemy(range);
        if(targetEnemy != null)
        {
            enemy = targetEnemy.GetComponent<Transform>();
            Laser();
        }
        else
        {
            TurnOfLaser();
        }
    }

    private void TurnOfLaser()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    public void Laser()
    {
        GiveDamage(enemy.GetComponent<Enemy>());
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, enemy.position);
    }

    private void GiveDamage(Enemy other)
    {
        if (!canDamage) return;
        other.TakeDamage(damage);
        canDamage = false;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(damageTime);
        canDamage = true;
    }
}
