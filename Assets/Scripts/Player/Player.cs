using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public HealthBar healthBar;

        public float maxHealth = 3333;
        public float currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        public void Heal(float heal)
        {
            currentHealth += heal;

            healthBar.SetHealth(currentHealth);

            if (currentHealth > maxHealth) currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0) Die();
        }

        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}