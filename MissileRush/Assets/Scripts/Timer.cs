using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float minutes;
    private float seconds;
    private float milliseconds;

    public Text timeText;

    void Update()
    {
        minutes = Time.time / 60;
        seconds = Time.time % 60;
        milliseconds = Time.time * 1000;
        milliseconds = milliseconds % 1000;

        timeText.text = Mathf.Floor(minutes) + ":" + Mathf.Floor(seconds) + ":" + Mathf.Floor(milliseconds);
    }
}
