using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

public class CylinderRespawn : MonoBehaviour
{
    public GameObject levelPrefab;
    private GameObject levelObject;

    private bool cylindersDestroyed = false;

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
                    TurnOnLight();

                    AudioSource source = levelObject.GetComponent<AudioSource>();
                    source.Play();
                    
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

    private async void TurnOnLight()
    {
        string json = "{\"data\": {\"switch\" : \"" + "on" + "\"}}";
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromMinutes(1);

        var endpoint = new System.Uri("http://192.168.0.111:8081/zeroconf/switch");

        var payload = new StringContent(json, encoding: Encoding.UTF8);
        var httpResponseMessage = await client.PostAsync(endpoint, payload);

        json = "{\"data\": {\"switch\" : \"" + "off" + "\"}}";
        payload = new StringContent(json, encoding: Encoding.UTF8);
        httpResponseMessage = await client.PostAsync(endpoint, payload);
    }
}
