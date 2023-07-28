using LootSystem;
using UnityEngine;

namespace Player
{
    public class Attractor : MonoBehaviour
    {
        public Transform player;
        private readonly float attractorSpeed = 10f;
        private Collectable collectable;
        private Transform item;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Collectable"))
            {
                collectable = collision.GetComponent<Collectable>();

                if (collectable.lootType is "XP" or "HEAL")
                {
                    item = collision.GetComponent<Transform>();
                    item.position = Vector2.Lerp(item.position, player.position, attractorSpeed * Time.fixedDeltaTime);
                }
            }
        }
    }
}