using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public int[] SkillLevels;
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;

    public List<Skill> SkillList;
    public GameObject SkillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public int SkillPoint;
    
    public GameManager GameManager;

    private void OnEnable()
    {
        GameManager.PauseToggle();
    }
    
    private void Start()
    {
        SkillLevels = new int[7];
        SkillCaps = new[] { 1, 5, 5, 2, 10, 10 };

        SkillNames = new[] { "Rotating Blades", "Laser Caster", "Upgrade 3", "Upgrade 4", "Booster 5", "Booster 6" };
        SkillDescriptions = new[]
        {
            "Create a rotating blade.",
            "Activate the laser caster.",
            "Does a really cool thing",
            "Does an awesome thing",
            "Does this math thing",
            "Does this compounding thing",
        };

        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>()) SkillList.Add(skill);
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>())
            ConnectorList.Add(ConnectorHolder.gameObject);
        {
            
        }

        for (var i = 0; i < SkillList.Count; i++) SkillList[i].id = i;

        SkillList[0].ConnectedSkills = new[] { 1, 2, 3 };
        SkillList[3].ConnectedSkills = new[] { 4, 5 };

        UpdateAllSkillUI();
    }

    public void UpdateAllSkillUI()
    {
        foreach (var skill in SkillList)
        {
            skill.UpdateUI();
        }
    }

    private void OnDisable()
    {
        GameManager.PauseToggle();
    }
}
