using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowGUI : MonoBehaviour
{
    public GameObject GUI;
    public GameObject EQtorch;
    public GameObject EQtrap;
    public GameObject EQpotion;
    public GameObject healthBar;
    public GameObject SpeedrunPop;
    void Update()
    {
        /* if (SceneManager.GetActiveScene().buildIndex == 2)
         {
             var leftTop = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
             var leftBottom = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
             GUI.transform.position = new Vector2(leftTop.x + (float)3.7, (leftTop.y - (float)2.25));
             healthBar.transform.position = new Vector2(leftTop.x + (float)4.81, (leftTop.y - (float)0.97));
             EQtorch.transform.position = new Vector2(leftBottom.x + (float)1.48, leftBottom.y + (float)1.8);
             EQtrap.transform.position = new Vector2(leftBottom.x + (float)+3.58, leftBottom.y + (float)1.8);
             EQpotion.transform.position = new Vector2(leftBottom.x + (float)+5.68, leftBottom.y + (float)1.8);
         }*/

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            var leftTop = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
            var leftBottom = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            GUI.transform.position = new Vector2(leftTop.x + (float)4.64, (leftTop.y - (float)2.8));
            healthBar.transform.position = new Vector2(leftTop.x + (float)6.38, (leftTop.y - (float)0.78));
            EQtorch.transform.position = new Vector2(leftBottom.x + (float)1.5, leftBottom.y + (float)1.5);
            EQtrap.transform.position = new Vector2(leftBottom.x + (float)+4.6, leftBottom.y + (float)1.5);
            EQpotion.transform.position = new Vector2(leftBottom.x + (float)+7.7, leftBottom.y + (float)1.5);
            SpeedrunPop.transform.position = new Vector2(leftTop.x + (float)38.95, (leftTop.y - (float)16.25));
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {

            var leftTop = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
            var leftBottom = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            GUI.transform.position = new Vector2(leftTop.x + (float)4.64, (leftTop.y - (float)2.8));
            healthBar.transform.position = new Vector2(leftTop.x + (float)6.38, (leftTop.y - (float)0.78));
            EQtorch.transform.position = new Vector2(leftBottom.x + (float)1.5, leftBottom.y + (float)1.5);
            EQtrap.transform.position = new Vector2(leftBottom.x + (float)+4.6, leftBottom.y + (float)1.5);
            EQpotion.transform.position = new Vector2(leftBottom.x + (float)+7.7, leftBottom.y + (float)1.5);
            SpeedrunPop.transform.position = new Vector2(leftTop.x + (float)38.95, (leftTop.y - (float)16.25));
        }
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
           
            var leftTop = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
            var leftBottom = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            GUI.transform.position = new Vector2(leftTop.x + (float)4.64, (leftTop.y - (float)2.8));
            healthBar.transform.position = new Vector2(leftTop.x + (float)6.38, (leftTop.y - (float)0.78));
            EQtorch.transform.position = new Vector2(leftBottom.x + (float)1.5, leftBottom.y + (float)1.5);
            EQtrap.transform.position = new Vector2(leftBottom.x + (float)+4.6, leftBottom.y + (float)1.5);
            EQpotion.transform.position = new Vector2(leftBottom.x + (float)+7.7, leftBottom.y + (float)1.5);
            SpeedrunPop.transform.position = new Vector2(leftTop.x + (float)38.95, (leftTop.y - (float)16.25));
        }
    }
}
