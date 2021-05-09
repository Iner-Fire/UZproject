using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedrunTime : MonoBehaviour
{
    public Text timer;
    float start;
    public float minutes, seconds;
    int isChangedTimer = 0;
    public playerMovement time;

    void Start()
    {
        playerMovement timer = time.GetComponent<playerMovement>();
        minutes = PlayerPrefs.GetFloat("timer_m");
        seconds = PlayerPrefs.GetFloat("timer_s");
        isChangedTimer = PlayerPrefs.GetInt("isChangedTimer");
        start = Time.time;
    }
    void Update()
    {
        playerMovement timerData = time.GetComponent<playerMovement>();
        float Timer = Time.time - start;
        if (isChangedTimer == 0)
        {
            minutes = ((int)Timer / 60);
            seconds = Timer % 60;
        }
        timer.text = "Time: " + minutes.ToString() + "." + seconds.ToString("F2");

    }

    
}
