using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returntogame : MonoBehaviour
{
    public void backToGame()
    {

        SceneManager.LoadScene("Game");
    }

}
