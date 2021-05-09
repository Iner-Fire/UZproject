using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followGUI : MonoBehaviour
{
    public GameObject GUI;
    public GameObject EQtorch;
    public GameObject EQtrap;
    public GameObject EQpotion;
    public GameObject healthBar;
    void Update()
    {
        var leftTop = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
        var leftBottom = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        GUI.transform.position = new Vector2(leftTop.x+(float)1.8, (leftTop.y - (float)1.5));
        healthBar.transform.position = new Vector2(leftTop.x + (float)2.41, (leftTop.y - (float)0.8));
        EQtorch.transform.position = new Vector2(leftBottom.x+(float)0.4, leftBottom.y+(float)0.58);
        EQtrap.transform.position = new Vector2(leftBottom.x+(float)+1.5, leftBottom.y+(float)0.58);
        EQpotion.transform.position = new Vector2(leftBottom.x+(float)+2.6, leftBottom.y+(float)0.58);
    }
}
