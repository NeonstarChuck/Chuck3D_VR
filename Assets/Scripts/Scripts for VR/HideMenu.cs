using UnityEngine;
using UnityEngine.InputSystem;

public class HideMenu : MonoBehaviour
{
    public GameObject menuCanvas; // Drag your Canvas here
    public InputActionReference toggleButton; // Bind to your Input Action here

    void Start()
    {
        menuCanvas.SetActive(false); // Ensure it's hidden
    }

    void OnEnable()
    {
        toggleButton.action.performed += ToggleMenu;
    }

    void OnDisable()
    {
        toggleButton.action.performed -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }
}
