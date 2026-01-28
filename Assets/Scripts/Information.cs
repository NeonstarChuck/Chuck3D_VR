using UnityEngine;

public class Information : MonoBehaviour
{
    public GameObject infoPanel; // Assign your InfoPanel in the Inspector

    // Show Panel when clicked
    public void ShowPanel()
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);
    }

    // Hide panel when clicked
    public void HidePanel()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}
