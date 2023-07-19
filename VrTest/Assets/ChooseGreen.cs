using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGreen : MonoBehaviour
{
    public GameObject ball;

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
        Debug.Log("Green ball selected!");

        ball.GetComponent<Renderer>().material.color = Color.green;
        ball.GetComponent<Rigidbody>().mass = 50;
    }
}
