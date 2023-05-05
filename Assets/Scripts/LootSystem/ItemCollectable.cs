using Unity.VisualScripting;
using UnityEngine;

public class ItemCollectable : MonoBehaviour
{
    public string itemType;
    public Item itemBase;
    public Level level;
    public CharacterStats characterStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //itemBase.SetStat();
        }
    }
}
