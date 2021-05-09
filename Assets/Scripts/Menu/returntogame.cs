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
        PlayerPrefs.SetInt("isCheckedSpeed", isChecked.isSpeedrun ? 1 : 0);
        Debug.Log("PO WCISNIECIU BAAAAAAAAAAAAAACK " +PlayerPrefs.GetInt("isCheckedSpeed"));
        SceneManager.LoadScene("Game");
        
    }

}
