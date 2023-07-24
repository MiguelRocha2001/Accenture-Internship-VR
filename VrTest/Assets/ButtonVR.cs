using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameObject ball;

    GameObject presser;
    AudioSource sound;
    bool isPressed;

    Color[] ballColors;
    int[] ballMass;
    int ballTypeIndex;

    Vector3 initialButtonLocalPos;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;

        ballColors = new Color[] { Color.red, Color.blue, Color.green };
        ballMass = new int[] { 10, 30, 50};
        ballTypeIndex = 0;
        initialButtonLocalPos = button.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, -0.7f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = initialButtonLocalPos;
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void OnButtonPressHandler()
    {
        /*
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = Vector3.one;
        sphere.transform.localPosition = new Vector3(0.5f, 4.45f, -17.81f);
        */

        // new ball configuration
        ballTypeIndex++;

        if (ballTypeIndex >= ballMass.Length)
            ballTypeIndex = 0;

        Color ballColor = ballColors[ballTypeIndex];
        int mass = ballMass[ballTypeIndex];

        // Assigns a material named "Assets/Resources/DEV_Orange" to the object.
        ball.GetComponent<Renderer>().material.color = ballColor;
        ball.GetComponent<Rigidbody>().mass = mass;
    }
}
