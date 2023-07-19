using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonHandler : MonoBehaviour
{
    public GameObject ball;

    public GameObject BlueBallButtonSelector;
    public GameObject GreenBallButtonSelector;
    public GameObject RedBallButtonSelector;
    public GameObject YellowBallButtonSelector;

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
        Debug.Log("Opening ball selectors");

        BlueBallButtonSelector.SetActive(true);
        GreenBallButtonSelector.SetActive(true);
        RedBallButtonSelector.SetActive(true);
        YellowBallButtonSelector.SetActive(true);
    }
}
