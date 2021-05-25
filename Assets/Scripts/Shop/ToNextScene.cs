using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    public Animator anim;
    public void NextScene()
    {
        if (PlayerPrefs.GetInt("CurrentSceneID") == 1)
            SceneManager.LoadScene(2);
        else if (PlayerPrefs.GetInt("CurrentSceneID") == 2)
            SceneManager.LoadScene(3);

    }
    public void ClickedNP()
    {
        anim.SetBool("No", true);
        anim.SetBool("Trigger", false);
    }
}
