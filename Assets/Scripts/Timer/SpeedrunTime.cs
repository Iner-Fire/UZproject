using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedrunTime : MonoBehaviour
{
    public Text timer;
    public Text death;
    public float start;
    public float minutes, seconds, hours;
    int isChangedTimer = 0;
    public playerMovement time;

    void Start()
    {
        if (PlayerPrefs.GetInt("saveData") == 1)
        {
            minutes = PlayerPrefs.GetFloat("timer_m");
            seconds = PlayerPrefs.GetFloat("timer_s");
            isChangedTimer = PlayerPrefs.GetInt("isChangedTimer");
            start = PlayerPrefs.GetFloat("start");
        }
        else
        start = Time.time;
    }
    void Update()
    {
        playerMovement deahtCounter = time.GetComponent<playerMovement>();
        float Timer = Time.time - start;
        seconds = Timer % 60;
        minutes = ((int)Timer / 60);
        hours = (int)Timer / 3600;
        timer.text = hours + ":" + minutes.ToString() + ":" + seconds.ToString("F2");
        death.text = deahtCounter.deathCounter.ToString();

    }

    
}
