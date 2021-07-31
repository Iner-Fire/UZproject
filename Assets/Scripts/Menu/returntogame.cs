using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returntogame : MonoBehaviour
{
    public SpeedrunMode speed;
    public void backToGame()
    {
        SpeedrunMode isChecked = speed.GetComponent<SpeedrunMode>();
        PlayerPrefs.SetInt("isCheckedSpeed", 1);
        int id = PlayerPrefs.GetInt("CurrentScene");
        SceneManager.LoadScene(id);
        
    }

}
