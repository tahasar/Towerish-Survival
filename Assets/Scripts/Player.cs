using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public HealthBar healthBar;
    public float power;


    public int araba1;
    public int araba2;
    public int araba3;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        
        currentHealth -= damage;//

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        
        healthBar.SetHealth(currentHealth);
    }
}
