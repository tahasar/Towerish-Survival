using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum Statistic
{
    Health,
    Mana,
    Attack,
    Defense,
    Magic,
    MagicDefense,
    Speed,
    Luck
}

[Serializable]
public class StatsValue
{
    public Statistic statisticType;
    public float value;

    public StatsValue(Statistic statisticType, int value = 0)
    {
        this.statisticType = statisticType;
        this.value = value;
    }
}

[Serializable]
public class StatsGroup
{
    public List<StatsValue> stats;
    

    public void Init()
    {
        stats = new List<StatsValue>();
        stats.Add(new StatsValue(Statistic.Health, 100));
        stats.Add(new StatsValue(Statistic.Mana, 100));
        stats.Add(new StatsValue(Statistic.Attack, 10));
        stats.Add(new StatsValue(Statistic.Defense, 10));
        stats.Add(new StatsValue(Statistic.Magic, 10));
        stats.Add(new StatsValue(Statistic.MagicDefense, 10));
        stats.Add(new StatsValue(Statistic.Speed, 10));
        stats.Add(new StatsValue(Statistic.Luck, 10));
    }


    internal StatsValue Get(Statistic statisticToGet)
    {
        return stats[(int)statisticToGet];
    }
}

public enum Attribute
{
    Strength,
    Dexterity,
    Intelligence,
    Vitality
}

[Serializable]
public class AttributeValue
{
    public Attribute attribute;
    public float value;
    
    public AttributeValue(Attribute attribute, float value = 0)
    {
        this.attribute = attribute;
        this.value = value;
    }
}

[Serializable]
public class AttributeGroup
{
    public List<AttributeValue> attributes = new List<AttributeValue>();
    
    public void Init()
    {
        attributes.Add(new AttributeValue(Attribute.Strength));
        attributes.Add(new AttributeValue(Attribute.Dexterity));
        attributes.Add(new AttributeValue(Attribute.Intelligence));
        attributes.Add(new AttributeValue(Attribute.Vitality));
    }
}

[Serializable]
public class ValuePool
{
    public StatsValue maxValue;
    public float currentValue;
    
    public ValuePool(StatsValue maxValue)
    {
        this.maxValue = maxValue;
        this.currentValue = maxValue.value;
    }
}


public class Stats : MonoBehaviour
{
    [SerializeField] private AttributeGroup attributes;
    [SerializeField] private StatsGroup stats;
    [SerializeField] private ValuePool health;
    
    private void Start()
    {
        attributes = new AttributeGroup();
        attributes.Init();
        
        stats = new StatsGroup();
        stats.Init();
        
        health = new ValuePool(TakeStats(Statistic.Health));
    }
    
    public void TakeDamage(float damage)
    {
        health.currentValue -= damage;
        
        Debug.Log($"Bu kadar canı kaldı: {health.currentValue}");
        
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health.currentValue <= 0)
        {
            Debug.Log("adam öldü");
        }
    }

    public StatsValue TakeStats(Statistic statisticToGet)
    {
        return stats.Get(statisticToGet);
    }
}

/*
public class Player : MonoBehaviour
{
    [SerializeField] private AttributeGroup attributes;
    [SerializeField] private StatsGroup stats;
    public HealthBar healthBar;

    public float maxHealth = 3333;
    public float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Start()
    {
        attributes = new AttributeGroup();
        attributes.Init();
        
        stats = new StatsGroup();
        stats.Init();
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
}*/