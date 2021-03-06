﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float minutes = 0;
    private float seconds = 0;
    private float milliseconds = 0;

    public Text timeText;

    void OnEnable()
    {
        minutes = 0;
        seconds = 0;
        milliseconds = 0;
    }

    void Update()
    {
		minutes = Time.timeSinceLevelLoad / 60;
		seconds = Time.timeSinceLevelLoad % 60;
		milliseconds = Time.timeSinceLevelLoad * 1000;
        milliseconds = milliseconds % 10;

		timeText.text = Mathf.Floor (minutes) + ":" + Mathf.Floor (seconds);// + ":" + Mathf.Floor(milliseconds);
    }
}
