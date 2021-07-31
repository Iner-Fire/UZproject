using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    private void Start()
    {
        //Bug fix
       // Screen.SetResolution(1920, 1080, true);
    }
    public RectTransform img;
    public void NextScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void NextSceneInto()
    {
        SceneManager.LoadScene("IntroCreatedBy");
    }
    public void SetResolution()
    {
        Debug.Log("width" + Screen.width + "height" + Screen.height);
        if (Screen.width != 1920 && Screen.height != 1080)
        {

            img.sizeDelta = new Vector2(Screen.width, Screen.height);
        }

    }
  
}
