using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedrunTime : MonoBehaviour
{
    public Text timer;
    float start;
    float minutes, seconds;

    void Start()
    {
        start = Time.time;
    }
    void Update()
    {
        float Timer = Time.time - start;
        minutes = ((int)Timer / 60);
        seconds = Timer % 60;
        timer.text = "Time: " + minutes.ToString() + "." + seconds.ToString("F2");

    }

    
}
