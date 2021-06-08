using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class followGUI : MonoBehaviour
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

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            var leftTop = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
            var leftBottom = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            GUI.transform.position = new Vector2(leftTop.x + (float)2.8, (leftTop.y - (float)1.65));
            healthBar.transform.position = new Vector2(leftTop.x + (float)3.95, (leftTop.y - (float)0.41));
            EQtorch.transform.position = new Vector2(leftBottom.x + (float)0.88, leftBottom.y + (float)0.95);
            EQtrap.transform.position = new Vector2(leftBottom.x + (float)+2.98, leftBottom.y + (float)0.95);
            EQpotion.transform.position = new Vector2(leftBottom.x + (float)+5.08, leftBottom.y + (float)0.95);
            SpeedrunPop.transform.position = new Vector2(leftTop.x + (float)20.95, (leftTop.y - (float)2.25));
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            var leftTop = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
            var leftBottom = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            GUI.transform.position = new Vector2(leftTop.x + (float)2.64, (leftTop.y - (float)1.6));
            healthBar.transform.position = new Vector2(leftTop.x + (float)3.58, (leftTop.y - (float)0.5));
            EQtorch.transform.position = new Vector2(leftBottom.x + (float)0.7, leftBottom.y + (float)0.9);
            EQtrap.transform.position = new Vector2(leftBottom.x + (float)+2.8, leftBottom.y + (float)0.9);
            EQpotion.transform.position = new Vector2(leftBottom.x + (float)+4.9, leftBottom.y + (float)0.9);
            SpeedrunPop.transform.position = new Vector2(leftTop.x + (float)19.95, (leftTop.y - (float)9.25));
        }
    }
}
