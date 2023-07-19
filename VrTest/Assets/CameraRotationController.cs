// Attach this script to the camera
using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    private void LateUpdate()
    {
        // Lock the camera's Z-axis rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
    }
}