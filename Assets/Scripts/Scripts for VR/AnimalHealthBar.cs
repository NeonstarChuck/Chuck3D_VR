using UnityEngine;
using UnityEngine.UI;

public class AnimalHealthBar : MonoBehaviour
{
    public AnimalHealth animal;
    public Image fillImage;

    void Update()
    {
        if (animal != null)
        {
            fillImage.fillAmount = animal.HealthNormalized;
        }
    }
}
