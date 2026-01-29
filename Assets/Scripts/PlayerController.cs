using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference moveAction;
    public InputActionReference shootAction;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float rotationSpeed = 10f; // how fast the player rotates
    public float xRange = 15.0f;
    public float zMin;
    public float zMax;
    public Transform projectileSpawnPoint;

    public GameObject projectilePrefab;

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(input.x, 0, input.y).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            // Move the player
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            // Rotate to face movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // --- Clamp position ---
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        float clampedZ = Mathf.Clamp(transform.position.z, -zMin, zMax);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        if (shootAction.action.WasPerformedThisFrame())
        {
            Instantiate(
                projectilePrefab,
                projectileSpawnPoint.position,
                projectileSpawnPoint.rotation
            );

            
        }

    }
}