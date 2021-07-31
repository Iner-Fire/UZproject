using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedRunToggle : MonoBehaviour
{
    public Toggle butt;

    public void SetSpeedRun()
    {
        if (butt.isOn)
        {
            PopUpTab.isChecked = 1;
        }
        else if (!butt.isOn)

        {
            PopUpTab.isChecked = 0;
            Debug.Log("false");
        }
    }
}
