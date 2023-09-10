using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public HealthBar healthBar;
        
        public Stat MaxHealth;
        public Stat CurrentHealth;

        private void Start()
        {
            GetStats();
            CurrentHealth.Value = MaxHealth.Value;
            healthBar.SetMaxHealth(MaxHealth.Value);
            healthBar.SetHealth(CurrentHealth.Value);
            SetStats();

        }

        public void Heal(float heal)
        {
            if (CurrentHealth == null)
            {
                Debug.Log("Current health is null");
            }

            if (CurrentHealth != null)
            {
                CurrentHealth.Value += heal;

                healthBar.SetHealth(CurrentHealth.Value);

                if (CurrentHealth.Value > MaxHealth.Value) CurrentHealth.Value = MaxHealth.Value;
            }

            SetStats();
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth.Value -= damage;

            healthBar.SetHealth(CurrentHealth.Value);

            if (CurrentHealth.Value <= 0) Die();
        }

        public virtual void Die()
        {
            Destroy(gameObject);
        }
        
        public void SetStats()
        {
            StatsManager.Instance.SetStatValue("MaxHealth", MaxHealth.Value);
            StatsManager.Instance.SetStatValue("CurrentHealth", CurrentHealth.Value);
        }

        public void GetStats()
        {
            MaxHealth.Value = StatsManager.Instance.stats.list.Find(element => element.key.Equals("MaxHealth")).value;
            CurrentHealth.Value = StatsManager.Instance.GetStatValue("CurrentHealth");
        }
    }
}