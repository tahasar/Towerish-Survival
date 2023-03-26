using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    
    public void Drop()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
    }
}
