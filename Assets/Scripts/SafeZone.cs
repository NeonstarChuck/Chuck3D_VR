using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        // Only objects with "Animal" tag
        if (other.CompareTag("Animal"))
        {
            if (gameManager != null)
                gameManager.AnimalRescued();

            Destroy(other.gameObject); // only destroy the animal
        }
    }
}
