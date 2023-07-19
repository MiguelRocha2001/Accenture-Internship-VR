using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0f;

    public GameObject corner0;
    public GameObject corner1;
    public GameObject corner2;
    public GameObject corner3;

    public GameObject player;

    public GameObject ball;

    private void Update()
    {
        Vector3 originalPosition = transform.position;

        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0, 2, -10);
        }

        // Read input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the input and the object's rotation
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection = transform.TransformDirection(movementDirection);

        // Move the object in the direction it is facing
        transform.position += movementDirection * speed * Time.deltaTime;

        if (corner0 != null && transform.position.z <= corner0.transform.position.z) // do not fall behind
        {
            transform.position = originalPosition;
        }

        if (corner1 != null && transform.position.x >= corner1.transform.position.x) // do not fall to the right
        {
            transform.position = originalPosition;
        }

        if (corner1 != null && transform.position.x <= corner2.transform.position.x) // do not fall to the left
        {
            transform.position = originalPosition;
        }

        if (corner1 != null && transform.position.z >= corner2.transform.position.z) // do not cross the line
        {
            transform.position = originalPosition;
        }

        // do not colide with the ball
        if (ball != null && transform.position.z <= ball.transform.position.z + 1 && transform.position.z >= ball.transform.position.z - 1 && transform.position.x <= ball.transform.position.x + 1 && transform.position.x >= ball.transform.position.x - 1)
        {
            transform.position = originalPosition;
        }
    }
}