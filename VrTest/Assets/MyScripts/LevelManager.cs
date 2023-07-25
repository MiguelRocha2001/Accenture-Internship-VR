using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class CylinderRespawn : MonoBehaviour
{
    public GameObject levelPrefab;
    private GameObject levelObject;

    private bool cylindersDestroyed = false;
    private int pinsFallen = 0;

    public int score = 0;

    private int blinkingInterval = 400;

    private bool isBlinking = false;

    void Start()
    {
        levelObject = Instantiate(levelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        updateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (cylindersDestroyed == false)
        {
            int pinsFallenUpdated = 0;
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Cylinder");
            foreach (GameObject cylinder in gameObjects)
            {
                Quaternion cylinderRotation = cylinder.transform.rotation;
                // Debug.Log("Cylinder rotation: x: " + cylinderRotation.x + " y: " + cylinderRotation.y + " z: " + cylinderRotation.z);
                if (cylinderRotation.x > 0.2 || cylinderRotation.x < -0.2 || cylinderRotation.z > 0.2 || cylinderRotation.z < -0.2)
                {
                    pinsFallenUpdated++;
                }
            }

            pinsFallen = pinsFallenUpdated;

            if (pinsFallen == 10)
            {
                if (levelObject != null)
                {
                    Destroy(levelObject); // Destroy the current instance

                    BlinkLight(3);

                    AudioSource source = GetComponent<AudioSource>();
                    source.Play(); // aplauses

                    cylindersDestroyed = true;
                }
            }
        }
        else
        {
            levelObject = Instantiate(levelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            cylindersDestroyed = false;
            pinsFallen = 0;

            IncrementScore();
        }
    }

    private void IncrementScore()
    {
        score++;
        updateScore(score);
    }

    private void updateScore(int newScore)
    {
        GameObject scoreGameObject = GameObject.FindGameObjectsWithTag("ScoreText")[0];
        TextMeshProUGUI scoreText = scoreGameObject.GetComponent<TextMeshProUGUI>();

        if (scoreText != null)
        {
            scoreText.text = "Score: " + newScore;
        }
        else
        {
            Debug.Log("Text is null");
        }
    }

    private async void BlinkLight(int times)
    {
        if (times == 0 || isBlinking) { return; }

        isBlinking = true;

        var client = new HttpClient();
        client.Timeout = TimeSpan.FromMinutes(1);
        var endpoint = new System.Uri("http://192.168.0.111:8081/zeroconf/switch");

        string turnOnJson = "{\"data\": {\"switch\" : \"" + "on" + "\"}}";
        string turnOfJson = "{\"data\": {\"switch\" : \"" + "off" + "\"}}";

        for (int i = 0; i < times; i++)
        {
            var payload = new StringContent(turnOnJson, encoding: Encoding.UTF8);
            var httpResponseMessage = await client.PostAsync(endpoint, payload);

            await Task.Delay(blinkingInterval);


            payload = new StringContent(turnOfJson, encoding: Encoding.UTF8);
            httpResponseMessage = await client.PostAsync(endpoint, payload);

            await Task.Delay(blinkingInterval);
        }

        isBlinking = false;
    }
}
