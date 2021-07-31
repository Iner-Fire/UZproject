using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTab : MonoBehaviour
{
    public GameObject tabWindow;
    public static int isChecked = 0;
    
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
