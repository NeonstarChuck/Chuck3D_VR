using UnityEngine;

public class AnimalHealth : MonoBehaviour
{
    public float maxHealth = 20f;
    public float hitDamage = 10f;   // 👈 damage per hit
    public ParticleSystem damageParticle;

    private float currentHealth;

    [HideInInspector]
    public GameManager gameManager;

    public float CurrentHealth => currentHealth;
    public float HealthNormalized => currentHealth / maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // 🔥 THIS IS THE IMPORTANT PART
    // Allows enemies using TakeHit() logic to damage animals
    public void TakeHit()
    {
        TakeDamage(hitDamage);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (damageParticle != null)
            damageParticle.Play();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameManager != null)
        {
            gameManager.AnimalDead();
        }

        Destroy(gameObject);
    }
}
