using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Read mouse movement
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the camera around its local axes based on mouse movement
        transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.Self);
    }
}
