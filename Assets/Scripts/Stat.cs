using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] public float baseValue;

    private List<float> modifiers = new List<float>();
}
