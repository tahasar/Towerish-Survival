using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseScreen : MonoBehaviour
{
    public GameObject characterSkills;
    public GameObject towerSkills;
    public GameObject skillTree;
    
    public void LoadCharacterSkills()
    {
        characterSkills.SetActive(true);
        gameObject.SetActive(false);
    }

    public void LoadTowerSkills()
    {
        towerSkills.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BackToChooseScreen()
    {
        characterSkills.SetActive(false);
        towerSkills.SetActive(false);
        gameObject.SetActive(true);
    }

    public void BackToGame()
    {
        skillTree.SetActive(false);
    }
}
