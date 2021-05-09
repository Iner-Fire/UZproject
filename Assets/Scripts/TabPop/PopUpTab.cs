using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTab : MonoBehaviour
{
    public GameObject tabWindow;
    int isChecked;

     void Start()
    {
       isChecked = PlayerPrefs.GetInt("isCheckedSpeed");
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab)) { 
            tabWindow.SetActive(true);
           
        }
        else
        {
            tabWindow.SetActive(false);
        }
    }
}
