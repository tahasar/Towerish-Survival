using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();

    public List<Item> items = new();
    public int inventorySize = 20;

    public OnItemChanged onItemChangedCallback;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
    }

    public bool Add(Item item)
    {
        if (items.Count >= inventorySize)
        {
            Debug.Log("Item alacak yerin yok.");
            return false;
        }

        items.Add(item);

        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
    }

    #region Singleton

    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("fazlafazfalza inventory");
            return;
        }

        Instance = this;
    }

    #endregion
}