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
        time.text = dateTime.Days.ToString() +" days \n"+ dateTime.Hours.ToString() +" hours \n"+ dateTime.Minutes.ToString() +" minutes \n"+ dateTime.Seconds.ToString()+" seconds";
    }
}
