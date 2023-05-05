using System;
using System.Collections.Generic;
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
            //foreach (float dict in item.stats)
            //{
            //    Debug.Log(dict);
            //}
        }
    }
}
