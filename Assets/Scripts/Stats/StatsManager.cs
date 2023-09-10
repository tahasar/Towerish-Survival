using System;
using System.Collections.Generic;
using UnityEngine;

public enum StatModType
{
    Override = 0,
    Flat = 1,
    PercentAdd = 2,
    PercentMult = 3,
}

[Serializable]
public class StatModifier
{
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source;

    public StatModifier(float value, StatModType type, int order, object source)
    {
        Value = value;
        Type = type;
        Order = order;
        Source = source;
    }

    public StatModifier(float value, StatModType type) : this(value, type, (int)type, null) { }
    public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }
    public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }
}

public class Stat
{
    public float BaseValue;
    private readonly List<StatModifier> _statModifiers;
    private bool _isDirty = true;
    private float _value;

    public Stat()
    {
        _statModifiers = new List<StatModifier>();
    }

    public float Value
    {
        get
        {
            if (_isDirty)
            {
                _value = CalculateFinalValue();
                _isDirty = false;
            }
            return _value;
        }
        set => throw new NotImplementedException();
    }

    public void AddModifier(StatModifier mod)
    {
        _isDirty = true;
        _statModifiers.Add(mod);
        _statModifiers.Sort(CompareModifierOrder);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (_statModifiers.Remove(mod))
        {
            _isDirty = true;
            return true;
        }
        return false;
    }

    public bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        for (int i = _statModifiers.Count - 1; i >= 0; i--)
        {
            if (_statModifiers[i].Source == source)
            {
                _isDirty = true;
                didRemove = true;
                _statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0;
    }

    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < _statModifiers.Count; i++)
        {
            StatModifier mod = _statModifiers[i];
            switch (mod.Type)
            {
                case StatModType.Override:
                    finalValue = mod.Value;
                    break;
                case StatModType.Flat:
                    finalValue += mod.Value;
                    break;
                case StatModType.PercentAdd:
                    sumPercentAdd += mod.Value;
                    if (i + 1 >= _statModifiers.Count || _statModifiers[i + 1].Type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                    break;
                case StatModType.PercentMult:
                    finalValue *= 1 + mod.Value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return (float)Math.Round(finalValue, 4);
    }
}

[Serializable]
public struct SerializableDictionaryElement<TKey, TValue>
{
    public TKey key;
    public TValue value;

    public SerializableDictionaryElement(TKey key, TValue value)
    {
        this.key = key;
        this.value = value;
    }
}

[Serializable]
public class SerializableDictionary<TKey, TValue>
{
    public List<SerializableDictionaryElement<TKey, TValue>> list;

    public Dictionary<TKey, TValue> ToDictionary()
    {
        var dictionary = new Dictionary<TKey, TValue>();
        foreach (var element in list)
        {
            dictionary[element.key] = element.value;
        }
        return dictionary;
    }

    public void SetValue(TKey key, TValue value)
    {
        var index = list.FindIndex(element => element.key.Equals(key));
        if (index >= 0)
            list[index] = new SerializableDictionaryElement<TKey, TValue>(key, value);
        else
            list.Add(new SerializableDictionaryElement<TKey, TValue>(key, value));
    }
}

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance { get; private set; }

    public SerializableDictionary<string, float> stats;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadStats();

        var statDict = stats.ToDictionary();
        foreach (var item in statDict)
        {
            Debug.Log(item.Key + ": " + item.Value);
        }
    }

    public void SaveStats()
    {
        foreach (var stat in stats.list)
        {
            PlayerPrefs.SetFloat(stat.key, stat.value);
        }
        PlayerPrefs.Save();
    }

    public void LoadStats()
    {
        foreach (var stat in stats.list)
        {
            if (PlayerPrefs.HasKey(stat.key))
            {
                stats.SetValue(stat.key, PlayerPrefs.GetFloat(stat.key));
            }
        }
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteAll();
    }

    public float GetStatValue(string statName)
    {
        var index = stats.list.FindIndex(element => element.key.Equals(statName));
        if (index >= 0)
        {
            return stats.list[index].value;
        }
        else
        {
            SetStatValue(statName, 1f);
            return 1f;
        }
    }

    public void SetStatValue(string statName, float newValue)
    {
        stats.SetValue(statName, newValue);
    }
}