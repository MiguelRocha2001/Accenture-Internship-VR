using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 initialPosition;
    public Vector3 previousVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if ball falls, respawns
        if(transform.position.y <= -10)
        {
            transform.position = initialPosition;

            // Set a new velocity for the sphere with 0
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        // if ball stops, respawns
        if(previousVelocity != Vector3.zero && GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            transform.position = initialPosition;

            previousVelocity = Vector3.zero;
        }
    }

    public void ResetPosition()
    {
        Debug.Log("Resetting ball");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = initialPosition;
    }
}
