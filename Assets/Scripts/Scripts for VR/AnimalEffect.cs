using UnityEngine;

public class AnimalEffect : MonoBehaviour
{
    private Vector3 originalScale;
    private Color originalColor;
    private Renderer rend;

    void Start()
    {
        originalScale = transform.localScale;

        rend = GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            originalColor = rend.material.color;
        }
    }

    public void ApplyEffect()
    {
        // Make bigger
        transform.localScale = originalScale * 1.5f;

        // Change color safely
        if (rend != null)
        {
            rend.material.color = Color.green;
        }

        Invoke(nameof(ResetEffect), 5f);
    }

    void ResetEffect()
    {
        transform.localScale = originalScale;

        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }
}
