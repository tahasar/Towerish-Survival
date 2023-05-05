using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public HealthBar HealthBar;

    public float maxHealth = 3333;
    public float currentHealth { get; private set; }
    
    [SerializeField] public Stat damage;
    [SerializeField] public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(10);
        }
    }
    
    public void Heal(float heal)
    {
        currentHealth += heal;
        
        HealthBar.SetHealth(currentHealth);

        if (currentHealth > maxHealth) ;
        {
            currentHealth = maxHealth;
        }

    }

    public void TakeDamage(float damage)
    {
        damage -= armor.GetValue();

        damage = Mathf.Clamp(damage, 0, float.MaxValue);
        
        currentHealth -= damage;
        
        HealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
