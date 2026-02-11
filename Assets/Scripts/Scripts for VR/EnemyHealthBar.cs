using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyHealth enemy;
    public Image fillImage;

    void Update()
    {
        if (enemy != null)
        {
            fillImage.fillAmount = enemy.HealthNormalized;
        }
    }
}
