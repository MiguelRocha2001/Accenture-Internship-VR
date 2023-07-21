using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundManager : MonoBehaviour
{
    private float initialY;
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (previousPosition.y > initialY && transform.position.y <= initialY) 
        { 
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }
        previousPosition = transform.position;
    }
}
