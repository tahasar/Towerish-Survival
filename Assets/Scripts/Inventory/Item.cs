using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public StatType ItemType;
    public Sprite icon = null;
    public bool isStackable = false;
    
    [SerializeField]
    public List<Dictionary1> stats;
}

[Serializable]
public struct Dictionary1
{
    public string stat;
    public float statValue;
}

public enum StatType
{
        Health,
        Armour,
        Magic,
        Potency
}