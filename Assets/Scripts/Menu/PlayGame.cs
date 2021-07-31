using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    private int sceneContinue;
     public void StartGame()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void Return()
    {
        sceneContinue = PlayerPrefs.GetInt("SavedScene");
        if (sceneContinue != 2)
            SceneManager.LoadScene(sceneContinue);
        else
            return;

    }
    public void StartGame2()
    {
        SceneManager.LoadScene("Game");
    }
}
