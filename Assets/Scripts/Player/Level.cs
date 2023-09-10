using Player;
using UnityEngine;

public class Level : MonoBehaviour
{
    public XpBar xpBar;
    public float level = 1;
    public int skillPoints = 3;
    public float experience;

    private float ToLevelUp => level * 20;

    public void AddExperience(float amount)
    {
        experience += amount;
        CheckLevelUp();
        xpBar.UpdateXpText(experience, ToLevelUp);
    }


    public void CheckLevelUp()
    {
        if (experience >= ToLevelUp)
        {
            experience -= ToLevelUp;
            level += 1;
            xpBar.UpdateLevelText(level);
        }
    }
}