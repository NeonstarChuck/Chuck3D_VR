using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHits = 4;
    private int currentHits = 0;

    public float HealthNormalized =>
        1f - (float)currentHits / maxHits;

    public void TakeHit()
    {
        currentHits++;

        if (currentHits >= maxHits)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
