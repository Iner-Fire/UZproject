using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTab : MonoBehaviour
{
    public GameObject tabWindow;
    int isChecked = 0;

     void Start()
    {
        if (PlayerPrefs.GetInt("isSpeedrun") == 1)
        {
            isChecked = PlayerPrefs.GetInt("isSpeedrun");
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && isChecked == 1) { 
            tabWindow.SetActive(true);
           
        }
        else
        {
            tabWindow.SetActive(false);
        }
    }
}
