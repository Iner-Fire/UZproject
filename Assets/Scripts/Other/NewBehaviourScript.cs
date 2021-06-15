using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    
    public Text text;

    private void Start()
    {
       
        DontDestroyOnLoad(text);
    }
    void Update()
    {
        text.text = ($"{Screen.width}, {Screen.height}, {Camera.main.orthographicSize}");
    }
}
