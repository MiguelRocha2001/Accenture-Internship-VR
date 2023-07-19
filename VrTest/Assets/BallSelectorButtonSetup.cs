using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelectorButtonSetup : MonoBehaviour
{
    public GameObject ball;
    public float newMass = 5f; // The new mass value you want to set

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
