using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class Grenade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float delay = 3f;
    public float radius = 5f;
    public GameObject explosionEffect;
    public AudioSource fuseAudio;
    float countdown;
    bool hasExploded = false;
    bool fuseStarted = false;
   
    void Start()
    {
        countdown = delay;
         GetComponent<XRGrabInteractable>()
            .selectEntered.AddListener(_ => PickUp());
    }

    // Update is called once per frame
    void Update()
    {
        if (!fuseStarted || hasExploded)
            return;

        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            Explode();
        }
        
    }
    void BlinkRed()
{
    Renderer r = GetComponentInChildren<Renderer>();
    if (r != null)
    {
        r.material.color =
            r.material.color == Color.red ? Color.white : Color.red;
    }
}

    void PickUp()
    {
        InvokeRepeating(nameof(BlinkRed), 0.5f, 0.5f);
        if (fuseStarted) return;

        fuseStarted = true;
        Debug.Log("Grenade fuse started!");
        if (fuseAudio != null)
    {
        fuseAudio.Play();
    }
        
    }
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

         Collider[] hits = Physics.OverlapSphere(transform.position, 3f);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Animal"))
            {
                AnimalEffect animal = hit.GetComponent<AnimalEffect>();
                if (animal != null)
                {
                    animal.ApplyEffect();
                }
            }
        }

        Debug.Log("Boom");
        Destroy(gameObject);
    }
}
