using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    // Assign the current camera controlling movement
    public Camera activeCamera;
    public Camera mainCamera; // third-person
    public Camera hoodCamera; // FPS

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = Vector3.zero;

        if (activeCamera == hoodCamera)
        {
            // First-person: movement relative to player's forward
            move = transform.forward * v + transform.right * h;
        }
        else
        {
            // Third-person: movement relative to world axes
            move = new Vector3(h, 0, v);
        }

        transform.position += move * speed * Time.deltaTime;
    }
}
