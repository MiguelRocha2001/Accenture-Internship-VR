using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CylinderRespawn : MonoBehaviour
{
    public GameObject levelPrefab;
    private GameObject levelObject;

    private bool cylindersDestroyed = false;
    private int throws = 0;

    public int score = 0;

    void Start()
    {
        levelObject = Instantiate(levelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (cylindersDestroyed == false)
        {
            int pinsFallen = 0;

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Cylinder");
            foreach (GameObject cylinder in gameObjects)
            {
                Quaternion cylinderRotation = cylinder.transform.rotation;
                // Debug.Log("Cylinder rotation: x: " + cylinderRotation.x + " y: " + cylinderRotation.y + " z: " + cylinderRotation.z);
                if (cylinderRotation.x > 0.5 || cylinderRotation.x < -0.5 || cylinderRotation.z > 0.5 || cylinderRotation.z < -0.5)
                {
                    pinsFallen++;
                }
            }

            if (pinsFallen == 10)
            {
                if (levelObject!= null)
                {
                    Destroy(levelObject); // Destroy the current instance
                }
                cylindersDestroyed = true;
            }
        }
        else
        {
            levelObject = Instantiate(levelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            cylindersDestroyed = false;

            IncrementScore();
        }

        GameObject sphere = GameObject.FindGameObjectsWithTag("Sphere")[0];
        /*
        if (sphere.IsInInitialPosition() == false && sphere.GetComponent<Rigidbody>().velocity > 0)
        {
            
        }
        */
        // Debug.Log("Number of pins fallen: " + pinsFallen);
    }

    private void IncrementScore()
    {
        score++;
        GameObject scoreText = GameObject.FindGameObjectsWithTag("ScoreText")[0];
        TextMeshProUGUI text = scoreText.GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = "Score: " + score;
        }
        else
        {
            Debug.Log("Text is null");
        }
    }
}
