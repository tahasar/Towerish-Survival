using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    
    [Header("Temel")]
    public Attractor attractor;
    public AttackCaster attackCaster;
    [Space]
    [Header("Silahlar")]
    public PurpleBaseAttack purpleBaseAttack;
    public LaserCaster laserCaster;
    public RotatingBladesManager rotatingBlade;

    // PurpleBaseAttack geliştirmeleri;
    public void Speed()
    {
        purpleBaseAttack.speed *= 3;
    }
    // rotateSpeed
    // range
    // damage
    
    
    // LaserCaster geliştirmeleri;
    //
    // range
    // damage
    // damageTime
    
    
    // RotatingBlade geliştirmeleri;
    //
    // rotateAroundSpeed
    // rotationSpeed
    // damage
}
