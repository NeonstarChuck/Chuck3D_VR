using UnityEngine;

public class Sword : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource hitAudio;   
    public AudioClip hitClip;          
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
             PlayHitSound();
        }
    }
    void PlayHitSound()
    {
        if (hitAudio == null) return;

        if (hitClip != null)
            hitAudio.PlayOneShot(hitClip);
        else
            hitAudio.Play();
    }
}
