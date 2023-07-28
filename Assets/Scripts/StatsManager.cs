using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.Common;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance { get; private set; }
    
    [SerializeField] private AttributeGroup attributes;

    private void OnValidate()
    {
        attributes = new AttributeGroup();
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}

[Serializable]
public class AttributeGroup
{
    public List<AtributeValue> attributeValues;
    
    public AttributeGroup()
    {
        attributeValues = new List<AtributeValue>();
        attributeValues.Add(new AtributeValue(Attribute.Strength));
        attributeValues.Add(new AtributeValue(Attribute.Dexterity));
        attributeValues.Add(new AtributeValue(Attribute.Constitution));
        attributeValues.Add(new AtributeValue(Attribute.Intelligence));
        attributeValues.Add(new AtributeValue(Attribute.Wisdom));
        attributeValues.Add(new AtributeValue(Attribute.Charisma));
    }
}

[Serializable]
public class AtributeValue
{
    public Attribute attributeType;
    public int Value;
    
    public AtributeValue(Attribute attributeType, int value = 0)
    {
        this.attributeType = attributeType;
        Value = value;
    }

    public Dictionary<Attribute, float> stats = new Dictionary<Attribute, float>();
}

public class stats{
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int charisma;}

public enum Attribute
{
    Strength = 0,
    Dexterity = 1,
    Constitution = 2,
    Intelligence = 3,
    Wisdom = 4,
    Charisma = 5
}
