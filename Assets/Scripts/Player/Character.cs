using System;
using System.Collections.Generic;
using StatSystem;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class Character : MonoBehaviour
{
    public HealthBar healthBar;
    public StatController statController;

    public Stat attackPower;
    public float maxHealth = 3333;
    public float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        attackPower = statController.stats["AttackPower"] as Stat;
        
        attackPower.AddModifier(new StatModifier() {magnitude = 10, type = ModifierOperationType.Additive});
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log("Attack Power: " + attackPower.value);
        }
    }

    public void Heal(float heal)
    {
        currentHealth += heal;

        healthBar.SetHealth(currentHealth);

        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}