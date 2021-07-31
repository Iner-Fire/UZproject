using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedrunMode : MonoBehaviour
{
    public bool isSpeedrun = false;
    public void Speedrun() { 
    
            if (isSpeedrun)
        {
            
            isSpeedrun = false;
            Debug.Log(isSpeedrun);
            PlayerPrefs.SetInt("isSpeedrun", isSpeedrun ? 1 : 0);
        }
        else
        {
            isSpeedrun = true;
            Debug.Log(isSpeedrun);
            PlayerPrefs.SetInt("isSpeedrun", isSpeedrun ? 1 : 0);
        }
    }
}
