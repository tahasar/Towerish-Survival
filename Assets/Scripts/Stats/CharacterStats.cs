using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 3333;
    public float currentHealth { get; private set; }
    
    [SerializeField] public Stat damage;
    [SerializeField] public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
        damage -= armor.GetValue();

        damage = Mathf.Clamp(damage, 0, float.MaxValue);
        
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //die in somee way
    }
}
