using Player;
using UnityEngine;

namespace LootSystem
{
    public class Collectable : MonoBehaviour
    {
        public string lootType;
        public float xpAmount;
        public float healAmount;
        public Level level;
        public Player.Player player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (lootType == "XP")
                    level.AddExperience(xpAmount);
                else if (lootType == "HEAL") player.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}