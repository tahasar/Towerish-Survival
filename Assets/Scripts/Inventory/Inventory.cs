using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

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

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int inventorySize = 20;

    public bool Add(Item item)
    {
        if (items.Count >= inventorySize)
        {
            Debug.Log("Item alacak yerin yok.");
            return false;
        }
        
        items.Add(item);
        
        if(onItemChangedCallback != null){
            onItemChangedCallback.Invoke();
        }
        
        return true;

    }
    
    public void Remove(Item item)
    {
        items.Remove(item);
        
        if(onItemChangedCallback != null){
            onItemChangedCallback.Invoke();
        }
    }
}
