using UnityEngine;

public class PullProjectile : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 5f;
    //time before it destroys
    public Vector3 holdOffset = new Vector3(0, -0.5f, 2f);
    //where the animal will be held.

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //forward object
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {

            Vector3 holdPosition = player.position + player.transform.TransformDirection(holdOffset);
            other.transform.position = holdPosition;
            //if hit animal tag object, then offset snap to the player

            other.transform.SetParent(player);
            //animal child of player (just like hoodcamera child )

            if (other.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
                //stop it from moving.
            }


            if (other.TryGetComponent<AnimalMovement>(out AnimalMovement moveScript))
                moveScript.enabled = false;

            //check the animamlmovemnt script and disables.
            Destroy(gameObject);
        }
    }
}
