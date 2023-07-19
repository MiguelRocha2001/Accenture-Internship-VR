using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPositionAndVelocityAndOrientation()
    {
        // Set a new velocity for the sphere with 0
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        // reset orientation
        transform.rotation = Quaternion.identity;

        // Reset the ball to its initial position
        transform.position = initialPosition;
    }
}
