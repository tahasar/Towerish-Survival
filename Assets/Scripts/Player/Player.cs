using System;
using System.Data;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public HealthBar HealthBar;
    
    
    private void Start()
    {
        //maxHealth = StatsManager.Instance.playerMaxHealth;
        //currentHealth = maxHealth;
        //HealthBar.SetMaxHealth(maxHealth);


        currentHealth = maxHealth;
        //maxHealth = StatsManager.Instance.playerMaxHealth;
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
