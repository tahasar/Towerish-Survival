using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Kryz.CharacterStats;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public CharacterStat maxHealth;
    public float currentHealth;

    public HealthBar healthBar;
    public float power;

    public List<Upgrade> upgrades;
    public Upgrade araba;

    public int araba1;
    public int araba2;
    public int araba3;

    private void Start()
    {
        currentHealth = maxHealth.Value;
        healthBar.SetMaxHealth(maxHealth.Value);

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            upgrades.Add(araba);
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            bilmemne();
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            foreach (Upgrade upgrade in upgrades)
            {
                upgrade.UnApply();
            }
        }
        
        UpdateStats(0, attackChange:1,0);

    }

    private void bilmemne()
    {
        foreach (Upgrade upgrade in upgrades)
        {
            araba.Apply();
        }

        Debug.Log(power);
    }
    
    public void UpdateStats(int healthChange, int attackChange, int defenseChange) 
    {
        araba1 += healthChange;
        araba2 += attackChange;
        araba3 += defenseChange;
    }

    public void Heal(float heal)
    {
        maxHealth.AddModifier(new StatModifier(heal, StatModType.Flat, null));
        
        healthBar.SetHealth(maxHealth.Value);
    }

    public void TakeDamage(float damage)
    {
        maxHealth.AddModifier(new StatModifier(-damage, StatModType.Flat));
        
        if (maxHealth.Value <= 0)
        {
            Destroy(gameObject);
        }
        
        healthBar.SetHealth(maxHealth.Value);
    }
}
