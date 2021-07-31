using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    public Animator anim;
    public PlayerMovementShop counter;
    int saveData;
    public void NextScene()
    {
        if (PlayerPrefs.GetInt("CurrentSceneID") == 2)
        {
            
            PlayerPrefs.SetInt("goldAmount", counter.coins);
            PlayerPrefs.SetInt("torchAmount", counter.torches);
            PlayerPrefs.SetInt("potionAmount", counter.potions);
            PlayerPrefs.SetInt("trapAmount", counter.trap);
            saveData = 1;
            PlayerPrefs.SetInt("saveData", saveData);
            SceneManager.LoadScene(3);
        }
        else if (PlayerPrefs.GetInt("CurrentSceneID") == 3)
        {
            PlayerPrefs.SetInt("goldAmount", counter.coins);
            PlayerPrefs.SetInt("torchAmount", counter.torches);
            PlayerPrefs.SetInt("potionAmount", counter.potions);
            PlayerPrefs.SetInt("trapAmount", counter.trap);
            saveData = 1;
            PlayerPrefs.SetInt("saveData", saveData);
            SceneManager.LoadScene(4);
        }

    }
    public void ClickedNP()
    {
        anim.SetBool("No", true);
        anim.SetBool("Trigger", false);
    }
}
