using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Stat
{
    #region Singleton

    public static Stat instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fazlafazfalza inventory");
            return;
        }
        instance = this;
    }

    #endregion
    
    [SerializeField] private float baseValue;
    [SerializeField] private List<float> modifiers = new List<float>();

    public float GetValue()
    {
        return baseValue;
    }
    
    public void AddModifier(float modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier(float modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}