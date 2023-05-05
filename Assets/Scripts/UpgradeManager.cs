using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class UpgradeManager : MonoBehaviour
{
    #region Singleton

    public static UpgradeManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion

    public Stat health;
    public Stat mana;
    public Stat armor;
    public Stat energy;
    public Stat manaPer;
    public Stat armorPer;
    public Stat energyPer;
    public Stat manaPerMax;
    public Stat armorPerMax;
    public Stat energyPerMax;
    public Stat manaPerMaxMax;
}
