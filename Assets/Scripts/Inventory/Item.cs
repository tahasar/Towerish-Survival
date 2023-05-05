using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : SerializedScriptableObject
{
    new public string name = "New Item";
    public string ItemType;
    public Sprite icon = null;
    public bool isStackable = false;

    public void SetStat()
    {
        //UpgradeManager.instance.armor.AddModifier(10);
    }
}