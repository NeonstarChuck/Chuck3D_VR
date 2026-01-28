using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hoodCamera;
    public PlayerMovement playerMovement;

    public KeyCode switchKey = KeyCode.F;

    void Start()
    {
        mainCamera.enabled = true;
        hoodCamera.enabled = false;

        playerMovement.activeCamera = mainCamera;
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            bool fpsActive = !hoodCamera.enabled;

            mainCamera.enabled = !fpsActive;
            hoodCamera.enabled = fpsActive;

            // Update player movement camera reference
            playerMovement.activeCamera = fpsActive ? hoodCamera : mainCamera;
        }
    }
}
