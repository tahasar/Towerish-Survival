using System;
using UnityEngine;
using Kryz.CharacterStats;

public class Player : MonoBehaviour
{
    public Stat maxHealth;
    public Stat currentHealth { get; private set; }

    public HealthBar HealthBar;

    private void Start()
    {
        currentHealth.BaseValue = maxHealth.BaseValue;
        HealthBar.SetMaxHealth(maxHealth.BaseValue);
    }

    private void Update()
    {
        if (currentHealth.BaseValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float heal)
    {
        currentHealth.BaseValue += heal;
        
        HealthBar.SetHealth(currentHealth.BaseValue);
    }

    public void TakeDamage(float damage)
    {
        currentHealth.BaseValue -= damage;
        
        HealthBar.SetHealth(currentHealth.BaseValue);
    }
}
