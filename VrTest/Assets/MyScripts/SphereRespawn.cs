using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Respawn : MonoBehaviour
{
    Vector3 initialPosition;
    public Vector3 previousVelocity = Vector3.zero;
    public Vector3 playerPos;

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
            Debug.Log("Ball falled down. Respawning...");
            previousVelocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initialPosition;
            return;
        }

        Vector3 ballVelocity = GetComponent<Rigidbody>().velocity;

        Vector3 ballPos = transform.position;
        double playerBallDistance = Math.Pow(Math.Pow(ballPos.x - playerPos.x, 2) + Math.Pow(ballPos.y - playerPos.y, 2) + Math.Pow(ballPos.z - playerPos.z, 2), 0.5);

        Debug.Log("Player Ball Distasnce: " + playerBallDistance);


        // if ball stops, respawns
        if (playerBallDistance > 2 && transform.position.y <= initialPosition.y && previousVelocity != Vector3.zero && ballVelocity.x <= 1 && ballVelocity.y <= 1 && ballVelocity.z <= 1)  
        {
            Debug.Log("Ball stopped. Respawning...");
            previousVelocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initialPosition;
            return;
        }
        previousVelocity = ballVelocity;
    }
}
