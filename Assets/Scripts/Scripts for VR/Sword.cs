using UnityEngine;

public class Sword : MonoBehaviour
{
    public float hitCooldown = 0.25f;
    private float lastHitTime;

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time - lastHitTime < hitCooldown)
            return;

        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
        {
            lastHitTime = Time.time;
            enemy.TakeHit();
        }
    }
}
