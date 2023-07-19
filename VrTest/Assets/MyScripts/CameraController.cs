using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Vector3 previousMousePosition;

    private void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Check if the mouse button is pressed to update the movement
        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // Calculate the mouse movement since the last frame
            Vector3 mouseMovement = Input.mousePosition - previousMousePosition;

            // Translate the camera in its forward direction based on the mouse movement
            transform.Translate(transform.forward * mouseMovement.y * Time.deltaTime * movementSpeed, Space.World);
            transform.Translate(transform.right * mouseMovement.x * Time.deltaTime * movementSpeed, Space.World);

            previousMousePosition = Input.mousePosition;
        }
    }
}
