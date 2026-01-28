using UnityEngine;
using UnityEngine.AI;
using System.Linq; // for easy nearest-target lookup

public class NavigationScript : MonoBehaviour
{

    private Animator animator;
    private AudioSource enemyAudio;
    public AudioClip slimeSound;
    public ParticleSystem damageParticle;

    [Header("Targets")]
    public Transform player;
    public string animalTag = "Animal";

    [Header("Attack Settings")]
    public float damage = 10f;
    public float attackCooldown = 1f;
    private float lastAttackTime;

    [Header("Navigation Settings")]
    public float checkInterval = 1f; // how often to find new target
    private NavMeshAgent agent;
    private Transform currentTarget;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = player; // fallback target
        animator = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // periodically find closest animal
        timer += Time.deltaTime;
        if (timer >= checkInterval)
        {
            timer = 0f;
            FindClosestAnimal();
        }

        // move toward target
        if (currentTarget != null)
            agent.destination = currentTarget.position;
    }

    void FindClosestAnimal() //Finding objects with tag animal
    {
        GameObject[] animals = GameObject.FindGameObjectsWithTag(animalTag);

        if (animals.Length == 0)
        {
            currentTarget = player;
            return;
        }

        // find the nearest animal
        GameObject closest = animals
            .OrderBy(a => Vector3.Distance(transform.position, a.transform.position))
            .FirstOrDefault();

        currentTarget = closest != null ? closest.transform : player;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // only damage animals
        if (collision.gameObject.CompareTag(animalTag))
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                //Get information form animal health script
                AnimalHealth animal = collision.gameObject.GetComponent<AnimalHealth>();
                if (animal != null)
                {
                    if (damageParticle != null)
                        damageParticle.Play();

                    enemyAudio.PlayOneShot(slimeSound, 1);
                    animator.SetTrigger("Attack");
                    animator.SetTrigger("Attack2");
                    animal.TakeDamage(damage);

                }

                lastAttackTime = Time.time;
            }
        }
    }
}
