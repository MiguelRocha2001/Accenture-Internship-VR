using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private bool isGrabbing = false;
    private GameObject grabbedObject;
    private Vector3 initialGrabOffset;
    private Vector3 cameraVelocity;

    private float MAX_DISTANCE = 3;

    private void Update()
    {
      
        // Check for grab input (e.g., left mouse button)
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to determine the object to grab
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object is a sphere and has a Rigidbody
                if (hit.collider.gameObject.CompareTag("Sphere") && hit.collider.GetComponent<Rigidbody>() != null)
                {
                    // Grab the object
                    grabbedObject = hit.collider.gameObject;
                    if (TooFarAway()) return;

                    isGrabbing = true;

                    // Calculate the initial offset between the object's position and the grab point
                    initialGrabOffset = grabbedObject.transform.position - hit.point + new Vector3(1.5f, 0f, 0f);

                    // Store the initial velocity of the object
                    cameraVelocity = GetComponent<Rigidbody>().velocity;
                    GetComponent<Rigidbody>().isKinematic = true;

                    // Disable the object's physics while grabbing
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        // Release the grabbed object
        if (Input.GetMouseButtonUp(0) && isGrabbing)
        {
            // Re-enable the object's physics
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
    
                GetComponent<Rigidbody>().isKinematic = false;
            }

            // Reset grabbing variables
            grabbedObject = null;
            isGrabbing = false;
        }
    }

    private void FixedUpdate()
    {
        if (TooFarAway()) return;

        // Move the grabbed object to the grabber's position
        if (isGrabbing && grabbedObject != null)
        {
            Vector3 grabPosition = transform.position + initialGrabOffset;
            grabbedObject.GetComponent<Rigidbody>().MovePosition(grabPosition);
        }
    }

    private bool TooFarAway()
    {
        Debug.Log("X difference: " + (gameObject.transform.position.x - grabbedObject.transform.position.x));
        Debug.Log("Y difference: " + (gameObject.transform.position.y - grabbedObject.transform.position.y));
        Debug.Log("Z difference: " + (gameObject.transform.position.z - grabbedObject.transform.position.z));

        float xDifference = gameObject.transform.position.x - grabbedObject.transform.position.x;
        float yDifference = gameObject.transform.position.y - grabbedObject.transform.position.y;
        float zDifference = gameObject.transform.position.z - grabbedObject.transform.position.z;
        if (
             xDifference > MAX_DISTANCE | xDifference < -MAX_DISTANCE |
             yDifference > MAX_DISTANCE | yDifference < -MAX_DISTANCE |
             zDifference > MAX_DISTANCE | zDifference < -MAX_DISTANCE
        )
        {
            return true;
        }
        return false;
    }
}