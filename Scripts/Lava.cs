using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Lava : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timerDisplay;

    public float totalTime;
    public float currentTime;

    private void Start()
    {
        currentTime = totalTime;
    }

    public void Update()
    {
        timerDisplay.text = "time left:" + currentTime;

        currentTime = currentTime - Time.deltaTime;

        if (currentTime == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Application.Quit();
    }
}
