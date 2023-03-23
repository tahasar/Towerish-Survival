using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/New Upgrade", fileName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public Player player;
    public float power = 100;
    
    public void Apply()
    {
        player.power = power;
    }

    public void UnApply()
    {
        player.power -= power;
    }
}
