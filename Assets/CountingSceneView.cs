using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class CountingSceneView : MonoBehaviour
{

    TextMeshProUGUI time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        time = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>(true).First(x => x.name.Equals("TimeBox"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ChangeDateingTime(TimeSpan dateTime)
    {
        int totalDays = dateTime.Days;
        int years = totalDays / 365;
        int remainingDays = totalDays % 365;

        string timeText = "";

        if (years > 0)
        {
            timeText += years.ToString() + " years \n";
        }

        if (remainingDays > 0 || years == 0)
        {
            timeText += remainingDays.ToString() + " days \n";
        }

        timeText += dateTime.Hours.ToString() + " hours \n";
        timeText += dateTime.Minutes.ToString() + " minutes \n";
        timeText += dateTime.Seconds.ToString() + " seconds";

        time.text = timeText;
    }
}
