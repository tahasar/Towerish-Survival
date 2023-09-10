using LootSystem;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Transform player;
    private const float AttractorSpeed = 10f;
    private Collectable _collectable;
    private Transform _item;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            _collectable = collision.GetComponent<Collectable>();

            if (_collectable.lootType is "XP" or "HEAL")
            {
                _item = collision.GetComponent<Transform>();
                _item.position = Vector2.Lerp(_item.position, player.position, AttractorSpeed * Time.fixedDeltaTime);
            }
        }
    }
}