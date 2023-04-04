using System;
using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats;
using Kryz.CharacterStats.Examples;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Inventory inventory;
    
    private void Start()
    {
        inventory = Inventory.instance;
        Inventory.instance.onItemChangedCallback += OnItemChanged;
    }
    
    public void OnItemChanged()
    {
        foreach (Item item in inventory.items)
        {
            
        }
    }
}
