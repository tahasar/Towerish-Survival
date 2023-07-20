using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    private CharacterStats characterStats;

    public void Drop()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
    }
}