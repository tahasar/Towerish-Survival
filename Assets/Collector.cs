using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private GameEvent onItemCollected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
        {
            onItemCollected.TriggerEvent(other.transform, item);
        }
    }
}
