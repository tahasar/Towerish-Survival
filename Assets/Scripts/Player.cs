using System;
using UnityEngine;
using Kryz.CharacterStats;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth { get; private set; }

    public HealthBar HealthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        
        HealthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        HealthBar.SetHealth(currentHealth);
    }
}
