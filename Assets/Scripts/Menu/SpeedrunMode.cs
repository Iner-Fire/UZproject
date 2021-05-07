using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedrunMode : MonoBehaviour
{
    public bool isSpeedrun = false;
    public void Speedrun()
    {
        if (isSpeedrun)
            isSpeedrun = false;
        else
            isSpeedrun = true;
        Debug.Log(isSpeedrun);
    }
}
