using UnityEngine;
using UnityEngine.UI;

public class AnimalHealthBar : MonoBehaviour
{
    public AnimalHealth animalHealth;
    public Image fillImage;

    void Update()
    {
        if (animalHealth == null) return;

        fillImage.fillAmount =
            animalHealth.CurrentHealth / animalHealth.maxHealth;
    }
}
