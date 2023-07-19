using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBlue : MonoBehaviour
{
    public GameObject ball;
    public float newMass = 5f; // The new mass value you want to set

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyButtonHandler()
    {
        // Code to be executed when the button is clicked.
        Debug.Log("Blue ball selected!");

        // Assigns a material named "Assets/Resources/DEV_Orange" to the object.
        ball.GetComponent<Renderer>().material.color = Color.blue;
        ball.GetComponent<Rigidbody>().mass = newMass;
    }
}
