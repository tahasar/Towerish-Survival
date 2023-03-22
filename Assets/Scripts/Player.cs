using UnityEngine;
using StatSystem;
using Attribute = StatSystem.Attribute;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Attribute Health;

    public HealthBar HealthBar;
    
    private void Start()
    {
        StatController statController = GetComponent<StatController>();
        Health = statController.stats["Health"] as Attribute;
        maxHealth = Health.value;


        HealthBar.SetMaxHealth(Health.value);
    }

    private void Update()
    {
        if (Health.value <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float heal)
    {
        Health.AddModifier(new StatModifier
        {
            magnitude = heal,
            type = ModifierOperationType.Additive
        });
        
        HealthBar.SetHealth(Health.value);
    }

    public void TakeDamage(float damage)
    {
        Health.AddModifier(new StatModifier
        {
            magnitude = -damage,
            type = ModifierOperationType.Additive
        });
        
        HealthBar.SetHealth(Health.value);
    }
}
