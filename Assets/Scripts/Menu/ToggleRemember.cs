using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleRemember : MonoBehaviour
{
    public Toggle button;
    void Start()
    {
        if (PlayerPrefs.GetInt("isCheckedSpeed") == 1)
        {
            int isOn = PlayerPrefs.GetInt("isSpeedrun");
            if (isOn == 1)
                button.isOn = true;
            else if (isOn == 0)
                button.isOn = false;
        }
    }


}
