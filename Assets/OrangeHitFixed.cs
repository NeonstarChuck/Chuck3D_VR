using UnityEngine;

public class OrangeHitWorld : MonoBehaviour
{
    public string targetObjectName = "TeleportAnimals"; // name of your target GameObject in scene
    public float destroyDelay = 2f;  // orange lifetime after hitting

    private Transform teleportTarget;

    void Start()
    {
        // Find the target GameObject in the scene at runtime
        GameObject targetGO = GameObject.Find(targetObjectName);
        if (targetGO != null)
        {
            teleportTarget = targetGO.transform;
        }
        else
        {
            Debug.LogError("Teleport target not found! Make sure a GameObject named '" + targetObjectName + "' exists in the scene.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal") && teleportTarget != null)
        {
            // Move the animal to the world position of the target
            collision.gameObject.transform.position = teleportTarget.position;
            collision.gameObject.transform.rotation = teleportTarget.rotation;

            // If it has a Rigidbody, reset velocity to prevent physics glitches
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Destroy the orange after a short delay
            Destroy(gameObject, destroyDelay);
        }
    }
}

