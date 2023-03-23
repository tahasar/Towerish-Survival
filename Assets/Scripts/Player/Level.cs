using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public XpBar xpBar;
    public float level = 1;
    public int skillPoints = 3;
    public float experience;

    private float TO_LEVEL_UP
    {
        get
        {
            return level * 20;
        }
    }

    public void AddExperience(float amount)
    {
        experience += amount;
        CheckLevelUp();
        xpBar.UpdateXpText(experience,TO_LEVEL_UP);
    }


    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            xpBar.UpdateLevelText(level);
            
        }
    }
}
