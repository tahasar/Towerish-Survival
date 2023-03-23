using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    // DEFINE LIST WITH UPGRADES
    Upgrade[] _Upgrades = new Upgrade[]
    {
        new Upgrade { Name = "Attack speed (projectiles)", Description = "Increases shooting speed of projectiles by X%", Rarity = "Common", Increase = 20 },
        new Upgrade { Name = "Projectile damage", Description = "Increases projectile damage by X%", Rarity = "Common", Increase = 20 },
        new Upgrade { Name = "Projectile size", Description = "Increases size of projectiles by X%", Rarity = "Common", Increase = 30 },
        new Upgrade { Name = "Pierce", Description = "Increases number of enemies that projectile can pierce through +X", Rarity = "Rare", Increase = 1 },
        new Upgrade { Name = "Precision", Description = "Your projectiles are more accurate +X%", Rarity = "Common", Increase = 20},
        new Upgrade { Name = "Greater view", Description = "You will see in greater distance by X", Rarity = "Rare", Increase = 30 },
        new Upgrade { Name = "Crit chance", Description = "Greater chance to do crit by X%", Rarity = "Rare", Increase = 10 },
        new Upgrade { Name = "Crit multiplier", Description = "Crit does more damage by X", Rarity = "Common", Increase = 15 },
        new Upgrade { Name = "Area damage", Description = "Greater area damage by X%", Rarity = "Rare", Increase = 25 },
        new Upgrade { Name = "Train health", Description = "Increases hitpoints of the train by X%", Rarity = "Rare", Increase = 15 },
        new Upgrade { Name = "Train repair", Description = "Repairs your train by X", Rarity = "Rare", Increase = 5 },
        new Upgrade { Name = "Level up faster", Description = "Level up faster by X%", Rarity = "Epic", Increase = 5 }
};


    [SerializeField] private Button Upgrade_button1;
    [SerializeField] private Button Upgrade_button2;
    [SerializeField] private Button Upgrade_button3;
    [SerializeField] private Button Upgrade_button4;

    [SerializeField] private TextMeshProUGUI Upgrade_DescriptionText1;
    [SerializeField] private TextMeshProUGUI Upgrade_DescriptionText2;
    [SerializeField] private TextMeshProUGUI Upgrade_DescriptionText3;
    [SerializeField] private TextMeshProUGUI Upgrade_DescriptionText4;

    private void Start()
    {
        ButtonsSet();
    }

    public void ButtonsSet()
    {
        // CHOOSING UPGRADE FROM UPGRADE ARRAY
        List<int> availableUpgrades = new List<int>();
        for (int i = 0; i < _Upgrades.Length; i++)
        {
            availableUpgrades.Add(i);
        }

        ShuffleList(availableUpgrades);
        Upgrade Upgrade_1 = _Upgrades[availableUpgrades[0]];
        Upgrade Upgrade_2 = _Upgrades[availableUpgrades[1]];
        Upgrade Upgrade_3 = _Upgrades[availableUpgrades[2]];
        Upgrade Upgrade_4 = _Upgrades[availableUpgrades[3]];

        // Setting text
        Upgrade_button1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Upgrade_1.Name;
        Upgrade_button2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Upgrade_2.Name;
        Upgrade_button3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Upgrade_3.Name;
        Upgrade_button4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Upgrade_4.Name;

        // Replacing the X with increase value
        Upgrade_DescriptionText1.text = Upgrade_1.Description.Replace("X", Upgrade_1.Increase.ToString());
        Upgrade_DescriptionText2.text = Upgrade_2.Description.Replace("X", Upgrade_2.Increase.ToString());
        Upgrade_DescriptionText3.text = Upgrade_3.Description.Replace("X", Upgrade_3.Increase.ToString());
        Upgrade_DescriptionText4.text = Upgrade_4.Description.Replace("X", Upgrade_4.Increase.ToString());

        // Setting color of the buttons
        Dictionary<string, Color> rarityColors = new Dictionary<string, Color>();
        rarityColors.Add("Common", new Color(1, 1, 1, 1));
        rarityColors.Add("Rare", new Color(0.5f, 1f, 0.5f, 1));
        rarityColors.Add("Epic", new Color(0.75f, 0.25f, 0.75f, 1));


        Upgrade_button1.GetComponent<Image>().color = rarityColors[Upgrade_1.Rarity];
        Upgrade_button2.GetComponent<Image>().color = rarityColors[Upgrade_2.Rarity];
        Upgrade_button3.GetComponent<Image>().color = rarityColors[Upgrade_3.Rarity];
        Upgrade_button4.GetComponent<Image>().color = rarityColors[Upgrade_4.Rarity];
    }

    // UPGRADES
    public void UpgradeChosen(string Upgrade_chosen)
    {
        if (Upgrade_chosen == "Attack speed (projectiles)")
        {
            // Attack_speed += increase;
            Debug.Log("Attack speed (projectiles)");
        }
        else if (Upgrade_chosen == "Projectile damage")
        {
            Debug.Log("Projectile damage");
        }
        else if (Upgrade_chosen == "Projectile size")
        {
            Debug.Log("Projectile size");
        }
        else if (Upgrade_chosen == "Pierce")
        {
            Debug.Log("Pierce");
        }
        else if (Upgrade_chosen == "Precision")
        {
            Debug.Log("Precision");
        }
        else if (Upgrade_chosen == "Train health")
        {
            Debug.Log("Train health");
        }
        else if (Upgrade_chosen == "Train repair")
        {
            Debug.Log("Train repair");
        }
        else if (Upgrade_chosen == "Level up faster")
        {
            Debug.Log("Level up faster");
        }
        else if (Upgrade_chosen == "Greater view")
        {
            Debug.Log("Greater view");
        }
        else if (Upgrade_chosen == "Area damage")
        {
            Debug.Log("Area damage");
        }
        else if (Upgrade_chosen == "Crit chance")
        {
            Debug.Log("Crit chance");
        }
        else if (Upgrade_chosen == "Crit multiplier")
        {
            Debug.Log("Crit multiplier");
        }
    }

    // SHUFFLE LIST
    public void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public class Upgrade
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rarity { get; set; }
        public float Increase { get; set; }
    }
}
