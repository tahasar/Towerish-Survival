using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Transform player;
    private float attractorSpeed = 10f;
    private Transform item;
    private Collectable collectable;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
        {
            collectable = collision.GetComponent<Collectable>();
            
            if(collectable.lootType is "XP" or "HEAL")
            {
                item = collision.GetComponent<Transform>();
                item.position = Vector2.Lerp(item.position, player.position, attractorSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
